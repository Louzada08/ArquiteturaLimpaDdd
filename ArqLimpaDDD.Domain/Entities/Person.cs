using ArqLimpaDDD.Domain.Entities.Base;
using ArqLimpaDDD.Domain.Interfaces.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArqLimpaDDD.Domain.Entities
{
    [Table("person")]
    public class Person : BaseEntity, IAggregateRoot
    {
        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("gender")]
        public string Gender { get; set; }

        [Column("enabled")]
        public bool Enabled { get; set; }
        public Guid? CreatedById { get; set; }
        public User? CreatedBy { get; set; }

    }
}
