using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Modernization_SARFAB_Backend.Application.Interfaces.Authentication;
using Modernization_SARFAB_Backend.Domain.Entities.Authentication;
using Modernization_SARFAB_Backend.WebAPI.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Modernization_SARFAB_Backend.Infrastructure.Services
{
    public class JwtService : ITokenService
    {
        private readonly JwtOptions _jwtOptions;

        public JwtService(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public string GenerateToken(UserEntity user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var keyBytes = Encoding.UTF8.GetBytes(_jwtOptions.Key);
            var securityKey = new SymmetricSecurityKey(keyBytes);

            var creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}