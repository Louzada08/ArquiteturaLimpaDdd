using ArqLimpaDDD.Domain.Entities.Base;
using ArqLimpaDDD.Domain.Interfaces.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArqLimpaDDD.Domain.Entities
{
    [Table("person")]
    public class Person : BaseEntity, IAggregateRoot
    {
        [Column("first_name")]
        public string FirstName { get; set; } = string.Empty;

        [Column("last_name")]
        public string LastName { get; set; } = string.Empty;

        [Column("address")]
        public string Address { get; set; } = string.Empty;

        [Column("gender")]
        public string Gender { get; set; } = string.Empty;

        [Column("enabled")]
        public bool Enabled { get; set; }
        public Guid? CreatedById { get; set; }
        public User? CreatedBy { get; set; }

    }
}
