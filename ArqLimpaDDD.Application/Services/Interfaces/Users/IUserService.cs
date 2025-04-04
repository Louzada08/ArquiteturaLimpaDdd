using ArqLimpaDDD.Domain.Dtos;
using ArqLimpaDDD.Domain.Entities;
using ArqLimpaDDD.Domain.Filter;
using ArqLimpaDDD.Domain.ValueObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System.Security.Claims;

namespace ArqLimpaDDD.Application.Interfaces.Users;

public interface IUserService
{
    User GetById(Guid id);
    Task<User?> GetByEmail(string email);
    Task<User> Create(User user);
    Task<IList<User>> GetAll(UserFilter filter);
    Task<IList<User>> GetAllGerentes(string nomeLoja);
    Task<User?> ValidationUser(UserLoginDTO userLogin);
}
