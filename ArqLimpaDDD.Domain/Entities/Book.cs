using ArqLimpaDDD.Domain.Entities.Base;
using ArqLimpaDDD.Domain.Interfaces.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArqLimpaDDD.Domain.Entities;

[Table("books")]
public class Book : BaseEntity, IAggregateRoot
{
    [Column("author")]
    public string Author { get; set; }

    [Column("launch_date")]
    public DateTime Launch_Date { get; set; }

    [Column("price")]
    public decimal Price { get; set; }

    [Column("title")]
    public string title { get; set; }
    public Guid? CreatedById { get; set; }
    public User? CreatedBy { get; set; }

}
