namespace MDrop
{
    public class UserSettings : JsonSettings<UserSettings>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
