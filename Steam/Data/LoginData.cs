using System;
using System.Collections.Generic;
using System.Text;

namespace MDrop.Steam.Data
{
    public class LoginData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string TwoFactorCode { get; set; }
        public string EMailAuth { get; set; }
        public string LoginFriendlyName { get; set; }
        public string Captchagid { get; set; }
        public string Captcha_Text { get; set; }
        public string EMailSteamId { get; set; }
        public string RSATimestamp { get; set; }
        public string Remember_Login { get; set; }

    }
}
