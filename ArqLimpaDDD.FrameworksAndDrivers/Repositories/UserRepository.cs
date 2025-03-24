using AutoMapper;
using ArqLimpaDDD.Domain.Entities;
using ArqLimpaDDD.Domain.Interfaces.Repositories;
using ArqLimpaDDD.Domain.ValueObjects;
using ArqLimpaDDD.FrameWrkDrivers.Data.Context;
using ArqLimpaDDD.FrameWrkDrivers.Repositories.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ArqLimpaDDD.FrameWrkDrivers.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MySQLContext context, IMapper mapper) : base(context, mapper) { }

        public User ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(input: user.Password, SHA256.Create());
            var userResponse = _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
            return userResponse;
        }

        private string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            var builder = new StringBuilder();

            foreach (var item in hashedBytes)
            {
                builder.Append(item.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}