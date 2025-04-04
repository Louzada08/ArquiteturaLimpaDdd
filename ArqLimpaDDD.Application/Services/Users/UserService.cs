using ArqLimpaDDD.Application.Interfaces.Users;
using ArqLimpaDDD.Domain.Dtos;
using ArqLimpaDDD.Domain.Entities;
using ArqLimpaDDD.Domain.Filter;
using ArqLimpaDDD.Domain.Interfaces.Repositories;
using ArqLimpaDDD.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ArqLimpaDDD.Application.Services.Users;
public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public User GetById(Guid id)
    {
        var user = _repository.QueryableFor(p => p.Id == id)
                .FirstOrDefault();

        return user;
    }

    public async Task<User> Create(User user)
    {
        var ret = _repository.Create(user);
        await _repository.UnitOfWork.Commit();
        return ret;
    }

    //private object GeraJWT(string email)
    //{
    //    var user = _repository.ValidateCredentials(userCredentials);
    //    if (user == null) return null;

    //    var claims = new List<Claim>
    //        {
    //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
    //            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
    //        };

    //    var accessToken = _tokenService.GenerateAccessToken(claims);
    //    var refreshToken = _tokenService.GenerateRefreshToken();

    //    user.RefreshToken = refreshToken;
    //    user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

    //    _repository.RefreshUserInfo(user);

    //    DateTime createDate = DateTime.Now;
    //    DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);
    //    return new TokenVO(
    //        true,
    //        createDate.ToString(DATE_FORMAT),
    //        expirationDate.ToString(DATE_FORMAT),
    //        accessToken,
    //        refreshToken
    //    );
    //}

    public async Task<User?> GetByEmail(string email)
    {
        return await _repository.QueryableFor(p => p.FullName.Equals(email))
                        .FirstOrDefaultAsync();
    }

    public async Task<IList<User>> GetAll(UserFilter filter)
    {
        var filterQuery = await _repository
            .QueryableFor(pX =>
                (filter.Name == null || pX.UserName!.Contains(filter.Name)) &&
                (filter.FullName == null || pX.FullName!.Contains(filter.FullName)))
            .AsNoTracking()
            .ToListAsync();

        return filterQuery;
    }

    public async Task<IList<User>> GetAllGerentes(string nomeLoja)
    {
        if(string.IsNullOrEmpty(nomeLoja)) return new List<User>();

        var users = await _repository
            .QueryableFor(x => x.FullName!.Equals(nomeLoja))
            .AsNoTracking()
            .ToListAsync();

        return users;
    }

    public async Task<User?> ValidationUser(UserLoginDTO userLogin)
    {
        var pass = ComputeHash(userLogin.Password, new SHA256CryptoServiceProvider());

        var user = await _repository.QueryableFor(u => (u.Email == userLogin.Email) && 
            (u.Password == pass)).FirstOrDefaultAsync();
        
        if (user == null) return null;
 
        return user;
    }

    private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
    {
        Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
        return BitConverter.ToString(hashedBytes);
    }

}
