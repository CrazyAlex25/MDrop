namespace MDrop.Steam.Data
{
    internal class SteamKeyRSA
    {
        public bool Success { get; set; }
        public string Publickey_mod { get; set; }
        public string Publickey_exp { get; set; }
        public string Timestamp { get; set; }
        public string Token_gid { get; set; }
    }
}
