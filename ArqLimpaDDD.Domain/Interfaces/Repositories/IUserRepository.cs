using ArqLimpaDDD.Domain.Entities;
using ArqLimpaDDD.Domain.ValueObjects;

namespace ArqLimpaDDD.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User> 
    {
        User ValidateCredentials(UserVO user);
    }
}
