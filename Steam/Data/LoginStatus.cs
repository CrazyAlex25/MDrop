using System;
using System.Collections.Generic;
using System.Text;

namespace MDrop.Steam.Data
{
    public class LoginStatus
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public bool Requires_TwoFactor { get; set; }
        public bool Captcha_Needed { get; set; }
        public string Captcha_gid { get; set; }

        //public bool success { get; set; }
        //public bool requires_twofactor { get; set; }
        //public string message { get; set; }
        public bool EMailAuth_Needed { get; set; }
        public string EMailDomain { get; set; }
        public string EMailSteamId { get; set; }

        public byte[] CaptchaImg { get; set; }
    }
}
