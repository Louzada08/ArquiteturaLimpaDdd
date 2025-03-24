using ArqLimpaDDD.Domain.Entities;
using System.Security.Claims;

namespace ArqLimpaDDD.Application.Services.Token;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    ClaimsPrincipal GetPrincipalToken(string token);
}
