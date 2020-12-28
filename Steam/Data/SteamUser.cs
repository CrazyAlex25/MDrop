using System;

namespace MDrop.Steam.Data
{
    public class SteamUser
    {
        public SteamUser()
        {
            LoginData = new LoginData();
        }
        public SteamUser(string username, string password) : this()
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public string Username
        {
            get => LoginData.Username;
            set => LoginData.Username = value;
        }
        public string Password { get; set; }

        public string EMailCode
        {
            get => LoginData.EMailAuth;
            set => LoginData.EMailAuth = value;
        }
        public string Captcha
        {
            get => LoginData.Captcha_Text;
            set => LoginData.Captcha_Text = value;
        }
        public string TwoFactorCode
        {
            get => LoginData.TwoFactorCode;
            set => LoginData.TwoFactorCode = value;
        }


        internal LoginData LoginData { get; }
    }
}
