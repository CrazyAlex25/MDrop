namespace MDrop.Steam
{
    static class  SteamApiEndpoints
    {
        private const string baseUrl = "https://steamcommunity.com";

        public const string GetRSAKey = baseUrl + "/login/getrsakey/?username=";
        public const string DoLogin = baseUrl + "/login/dologin/";
        public const string Captcha = baseUrl + "/login/rendercaptcha/?gid=";
        public const string OpenId = baseUrl + "/openid/login";
    }
}
