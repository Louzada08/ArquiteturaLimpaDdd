using FluentValidation.Results;
using ArqLimpaDDD.Domain.Entities.Base;
using ArqLimpaDDD.Domain.Interfaces.Repositories;
using ArqLimpaDDD.Domain.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArqLimpaDDD.Domain.Entities
{
    [Table("users")]
    public class User : BaseEntity
    {
        public string? UserName { get; set; }
        public string? FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public UserRolesEnum UserRole { get; set; }

        public ValidationResultBag CancelCreationIfExists(IGenericRepository<User> repository, User entity)
        {
            var result = new ValidationResultBag();
            var dbUser = repository.QueryableFor(u => u.Email == entity.Email).FirstOrDefault();

            if (dbUser != null)
                result.Errors.Add(new ValidationFailure(nameof(entity.Email), "Este e-mail já está em uso."));

            return result;
        }

        public ValidationResultBag CancelChangeIfExists(IGenericRepository<User> repository, User entity)
        {
            var result = new ValidationResultBag();
            var dbUserEmail = repository.QueryableFor(u => u.Email == entity.Email).FirstOrDefault();

            if (dbUserEmail != null && dbUserEmail.Id != entity.Id)
                result.Errors.Add(new ValidationFailure(nameof(entity.Email), "Este e-mail já está em uso."));

            return result;
        }
    }
}
