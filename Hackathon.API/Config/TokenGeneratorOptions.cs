namespace Hackathon.API.Config
{
    public class TokenGeneratorOptions
    {
        public int ExpirationMinutes { get; set; }
        public string SecurityKey { get; set; }
    }
}
