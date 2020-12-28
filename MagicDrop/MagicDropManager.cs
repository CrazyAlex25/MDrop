using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using MDrop.Http;
using MDrop.Steam;

namespace MDrop.MagicDrop
{
    class MagicDropManager
    {
        public bool Authorized { get; set; }

        private readonly HttpClient http;
        public MagicDropManager(HttpClient httpClient)
        {
            http = httpClient;
        }


        public string OpenIdUrl => MagicDropApiEndpoints.Login;

        public async Task<bool> CheckAuthorizedAsync()
        {
            var response = await http.GetAsync(MagicDropApiEndpoints.FreeCaseReg);
            var status = await response.ReadAsJSON<MagicDropStatus>();

            return status.Auth_Err == 0 ? true : false;
        }

        public async Task<MagicDropStatus> RegisterFreeCaseAsync()
        {
            var reg = await http.PostAsync(MagicDropApiEndpoints.FreeCaseReg,
                new FormUrlEncodedContent(new Dictionary<string, string>() { { "caseName", "free" } }));
            var tmp = await reg.ReadAsJSON<MagicDropStatus>();
            return tmp;

        }

        public async Task<(string username,MagicDropWinner winner)> GetLastWinnerAsync()
        {
            var response = await http.GetAsync(MagicDropApiEndpoints.FreeCase);
            var html = await response.Content.ReadAsStringAsync();

            return await HTMLUtils.GetMagicDropWinner(html);
            
        }
    }
}
