using ArqLimpaDDD.Domain.Entities.Base;
using ArqLimpaDDD.Domain.Interfaces.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArqLimpaDDD.Domain.Entities;

[Table("books")]
public class Book : BaseEntity, IAggregateRoot
{
    public string author { get; set; }
    public DateTime launch_date { get; set; }
    public decimal? price { get; set; }
    public string title { get; set; }
    public Guid? CreatedById { get; set; }
    public User? CreatedBy { get; set; }

}
