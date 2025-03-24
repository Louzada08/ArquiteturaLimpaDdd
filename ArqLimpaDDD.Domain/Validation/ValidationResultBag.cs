using FluentValidation.Results;

namespace ArqLimpaDDD.Domain.Validation;

public class ValidationResultBag : ValidationResult
{
    public object? Data { get; set; }
}
