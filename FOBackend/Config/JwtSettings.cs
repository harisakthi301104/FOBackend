namespace FOBackend.Config
{
    // Settings class to map JWT config from appsettings.json
    public class JwtSettings
    {
        // Secret key used to sign JWT tokens
        public string SecretKey { get; set; } = string.Empty;

        // Token issuer (our API)
        public string Issuer { get; set; } = string.Empty;

        // Token audience (our Angular app)
        public string Audience { get; set; } = string.Empty;

        // Token expiry in minutes
        public int ExpiryMinutes { get; set; } = 60;
    }
}
