namespace ArqLimpaDDD.Domain.Interfaces.Base;

public interface IBase
{
    public Guid Id { get; set; }
    public DateTime? createdat { get; set; }
    public DateTime? updatedat { get; set; }
    public DateTime? deletedat { get; set; }

}
