using ArqLimpaDDD.Domain.Entities;
using ArqLimpaDDD.Domain.Messages;

namespace ArqLimpaDDD.Application.Commands.Users.Requests;

public class CreateUserRequest : Command
{
    public string UserName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiryTime { get; set; }
    public UserRolesEnum UserRole { get; set; }
}
