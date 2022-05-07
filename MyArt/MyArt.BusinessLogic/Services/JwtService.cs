using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyArt.API.ViewModels;
using MyArt.BusinessLogic.Contracts;
using MyArt.BusinessLogic.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyArt.BusinessLogic.Services
{
    public class JwtService : IJwtService
    {
        private readonly IOptions<JwtOptions> _options;

        public JwtService(IOptions<JwtOptions> options)
        {
            _options = options;
        }

        public string GenerateToken(UserViewModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.SecretKey);

            var Subject = new List<Claim>() {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _options.Value.Issuer,
                audience: _options.Value.Audience,
                claims: Subject,
                expires: DateTime.UtcNow.AddDays(70),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            return tokenHandler.WriteToken(token);
        }
    }
}
