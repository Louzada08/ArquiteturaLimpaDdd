using ArqLimpaDDD.Domain.Entities;
using ArqLimpaDDD.Domain.Filter;

namespace ArqLimpaDDD.Application.Interfaces.Users;

public interface IUserService
{
    User GetById(Guid id);
    Task<User?> GetByEmail(string email);
    Task<User> Create(User user);
    Task<IList<User>> GetAll(UserFilter filter);
    Task<IList<User>> GetAllGerentes(string nomeLoja);
}