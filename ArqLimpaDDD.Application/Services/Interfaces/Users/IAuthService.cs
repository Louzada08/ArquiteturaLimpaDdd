using ArqLimpaDDD.Domain.Entities;
using System.Security.Claims;

namespace ArqLimpaDDD.Domain.Interfaces.Users;

public interface IAuthService
{
    ClaimsPrincipal GetLoggedUserData();
    Task<User?> GetLoggedUserDbDataAsync();
    Task<bool> CreateUserOnFirstAccess();

}