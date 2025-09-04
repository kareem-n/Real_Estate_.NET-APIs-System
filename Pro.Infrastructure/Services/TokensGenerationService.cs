
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pro.Domain.Interfaces.Services;
using Pro.Domain.Models;

namespace Pro.Infrastructure.Services
{
    public class TokensGenerationService : ITokensGeneratorService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IConfiguration configuration;

        public TokensGenerationService(UserManager<AppUser> roleManager, IConfiguration configuration)
        {
            this.userManager = roleManager;
            this.configuration = configuration;
        }
        public async Task<string> GenerateJWTToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new (JwtRegisteredClaimNames.UniqueName, user.UserName!),
                new (JwtRegisteredClaimNames.Sub, user.Id),
                new (JwtRegisteredClaimNames.Email, user.Email!),
            };

            var roles = await userManager.GetRolesAsync(user);
            claims.Add(new Claim(ClaimTypes.Role, string.Join(", ", roles)));

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["JWT:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public bool ValidateToken(string token)
        {
            throw new NotImplementedException();
        }
    }
}
