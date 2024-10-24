using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MyApp.Api.Configuration {

    public static class JwtSettingsExtensions {
        public static TokenValidationParameters ToTokenValidationsParameters(this JwtSettings settings){
            return new TokenValidationParameters {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = settings.ValidIssuer,
                ValidAudience = settings.ValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.IssuerSigningKey))
            };
        }
    }
}