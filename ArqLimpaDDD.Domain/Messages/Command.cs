using FluentValidation.Results;
using MediatR;
using ArqLimpaDDD.Domain.Validation;

namespace ArqLimpaDDD.Domain.Messages;
public abstract class Command : IRequest<ValidationResultBag>
{
    public DateTime Timestamp { get; private set; }
    public ValidationResult ValidationResult { get; set; }

    protected Command() => Timestamp = DateTime.Now;

    public virtual bool IsValid()
    {
        throw new NotImplementedException();
    }
}
