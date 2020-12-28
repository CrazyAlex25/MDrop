using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;

using MDrop.Http;
using MDrop.Steam.Data;

namespace MDrop.Steam
{
    public class SteamLoginManager
    {
        private readonly HttpClient http;

        public SteamLoginManager(HttpClient httpClient)
        {
            http = httpClient;
        }

        private async Task<SteamKeyRSA> GetKeyAsync(SteamUser user)
        {
            var response = await http.GetAsync(SteamApiEndpoints.GetRSAKey + user.Username);
            var rsa = await response.ReadAsJSON<SteamKeyRSA>();
            return rsa;
        }

        private FormUrlEncodedContent PropertyToString<T>(T obj)
        {
            var properties = obj.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            var dic = new Dictionary<string, string>(properties.Length);

            foreach (var p in properties)
            {
                dic[p.Name.ToLower()] = (string)p.GetValue(obj);
            }
            return new FormUrlEncodedContent(dic);
        }

        private async Task<LoginStatus> TryLoginAsync(SteamUser user)
        {
            var rsa = await GetKeyAsync(user);

            var encryptedPassword = SteamCrypt.GetPassword(rsa.Publickey_mod, rsa.Publickey_exp, user.Password);

            user.LoginData.Password = encryptedPassword;
            user.LoginData.RSATimestamp = rsa.Timestamp;
            user.LoginData.Remember_Login = "true";

            var dic = PropertyToString(user.LoginData);

            var result = await http.PostAsync(SteamApiEndpoints.DoLogin, dic);

            var status = await result.ReadAsJSON<LoginStatus>();
            return status;

        }


        public async Task<LoginStatus> Login(SteamUser user)
        {
            var loginResult = await TryLoginAsync(user);
            user.LoginData.Captchagid = loginResult.Captcha_gid;

            if (loginResult.Captcha_Needed)
            {
                loginResult.CaptchaImg = await http.GetByteArrayAsync(SteamApiEndpoints.Captcha + loginResult.Captcha_gid);
            }
            return loginResult;

        }

        public async Task<bool> LoginOpenIdAsync(string url)
        {
            var response = await http.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            var dic=await HTMLUtils.GetSteamOpenId(content);
            if (dic.Count == 0)
                return false;

            response = await http.PostAsync(SteamApiEndpoints.OpenId, new FormUrlEncodedContent(dic));

            //HACK: allow https->http redirect
            if(response.StatusCode==HttpStatusCode.Redirect)
            {
                response = await http.GetAsync(response.Headers.Location);
            }
            return true;
        }
    }
}
