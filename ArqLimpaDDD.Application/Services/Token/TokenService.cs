using ArqLimpaDDD.Application.Interfaces.Users;
using ArqLimpaDDD.Domain.Entities;
using ArqLimpaDDD.Domain.ValueObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ArqLimpaDDD.Application.Services.Token;

public class TokenService : ITokenService
{
    private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";

    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public TokenService(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }
    
    public TokenVO GenerateAccessToken(string email, UserRolesEnum userRole, IList<Claim> claims)
    { 
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenConfigurations:Secret"] ?? string.Empty));
        var issuer = _configuration["TokenConfigurations:Issuer"];
        var audience = _configuration["TokenConfigurations:Audience"];
        var expires = DateTime.Now.AddMinutes(int.Parse(_configuration["TokenConfigurations:Minutes"] ?? "2"));

        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, email));
        claims.Add(new Claim(ClaimTypes.Email, email));

        //foreach (var elem in Enum.GetValues(typeof(UserRolesEnum)))
        //{
        //    claims.Add(new Claim(ClaimTypes.Role, EnumExtensions.GetEnumDescription((Enum)elem)));
        //}


        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            //claims: new[]
            //{
            //    new Claim(ClaimTypes.Name, email),
            //    new Claim(ClaimTypes.Role, userRole.ToString())
            //},

            expires: expires,
            signingCredentials: signingCredentials
        );


        var tokenHandler = new JwtSecurityTokenHandler();

        var refreshToken = GenerateRefreshToken();

        DateTime createDate = DateTime.Now;
        DateTime expirationDate = expires;

        return new TokenVO(
            true,
            createDate.ToString(DATE_FORMAT),
            expirationDate.ToString(DATE_FORMAT),
            tokenHandler.WriteToken(token),
            refreshToken
            );
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
          //  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Secret)),
            ValidateLifetime = false
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;

        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || 
            !jwtSecurityToken.Header.Alg.Equals(
                SecurityAlgorithms.HmacSha256, 
                StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");
        return principal;
    }

    public ClaimsPrincipal GetPrincipalToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
        };

        ClaimsPrincipal principal = null;
        return principal;
    }

}
