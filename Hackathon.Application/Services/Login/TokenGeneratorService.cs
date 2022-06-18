using Hackathon.Application.Interfaces;
using Hackathon.Application.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Hackathon.Application.Services.Login
{
    public class TokenGeneratorService :  ITokenGeneratorService
    {
        private readonly TokenGeneratorOptions _options;
        public TokenGeneratorService(IOptions<TokenGeneratorOptions> options)
        {
            if (options.Value is null)
                throw new ArgumentNullException(nameof(options.Value));

            _options = options.Value;
        }
        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.SecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_options.ExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
