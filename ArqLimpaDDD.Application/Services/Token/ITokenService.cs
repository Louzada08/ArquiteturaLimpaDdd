using ArqLimpaDDD.Domain.Entities;
using ArqLimpaDDD.Domain.ValueObjects;
using System.Security.Claims;

namespace ArqLimpaDDD.Application.Services.Token;

public interface ITokenService
{
    TokenVO GenerateAccessToken(string email, UserRolesEnum userRole, IList<Claim> claims);
    string GenerateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    ClaimsPrincipal GetPrincipalToken(string token);
}
