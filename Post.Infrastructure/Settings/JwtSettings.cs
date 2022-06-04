namespace Post.Infrastructure.Settings
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public int ExpiryMinutes { get; set; }
    }
}