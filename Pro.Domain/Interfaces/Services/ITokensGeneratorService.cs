
using Pro.Domain.Models;

namespace Pro.Domain.Interfaces.Services
{
    public interface ITokensGeneratorService
    {
        /// <summary>
        /// Generates a JWT token for the given user ID.
        /// </summary>
        /// <param name="userId">The ID of the user for whom the token is generated.</param>
        /// <returns>A string representing the generated JWT token.</returns>
        public Task<string> GenerateJWTToken(AppUser user);

        bool ValidateToken(string token);
    }
}
