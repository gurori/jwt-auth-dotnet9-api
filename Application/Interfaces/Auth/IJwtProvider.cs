using System.Security.Claims;
using Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace Application.Interfaces.Auth
{
    public interface IJwtProvider
    {
        public Task<string> GenerateTokenAsync(User user);
        public Task<TokenValidationResult> ValidateTokenAsync(string token);
    }
}
