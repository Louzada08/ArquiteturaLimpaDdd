using ArqLimpaDDD.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ArqLimpaDDD.Domain.Dtos;

public class UserDTO
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string? RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiryTime { get; set; }
    public UserRolesEnum UserRole { get; set; }
}

public class UserLoginDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
}

public class UsuarioRespostaLogin
{
    public string AccessToken { get; set; }
    public double ExpiresIn { get; set; }
    public UsuarioToken UsuarioToken { get; set; }
}
public class UsuarioToken
{
    public string Id { get; set; }
    public string Email { get; set; }
    public IEnumerable<UsuarioClaim> Claims { get; set; }
}

public class UsuarioClaim
{
    public string Value { get; set; }
    public string Type { get; set; }
}
