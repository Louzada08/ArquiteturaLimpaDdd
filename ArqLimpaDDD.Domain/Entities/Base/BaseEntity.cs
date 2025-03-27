using ArqLimpaDDD.Domain.Interfaces.Base;

namespace ArqLimpaDDD.Domain.Entities.Base;

public class BaseEntity : IBase
{
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }

    public BaseEntity(DateTime createdAt) : this()
    {
        createdat = createdAt;
    }

    public BaseEntity(Guid id, DateTime createdAt)
    {
        Id = id;
        createdat = createdAt;
    }

    public Guid Id { get; set; }
    public DateTime? createdat { get; set; }
    public DateTime? updatedat { get; set; }
    public DateTime? deletedat { get; set; }
}
