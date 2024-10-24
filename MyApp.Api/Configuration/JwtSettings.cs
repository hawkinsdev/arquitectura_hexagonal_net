using Microsoft.IdentityModel.Tokens;

namespace MyApp.Api.Configuration {
    public class JwtSettings {
        public required string ValidIssuer { get; set; }
        public required string ValidAudience { get; set; }
        public required string IssuerSigningKey { get; set; }

    }
}