using ArqLimpaDDD.Domain.Entities;
using System.Security.Claims;

namespace ArqLimpaDDD.Application.Services.Token;

public interface ITokenService
{
    string GenerateAccessToken(string email, UserRolesEnum userRole);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    ClaimsPrincipal GetPrincipalToken(string token);
}
