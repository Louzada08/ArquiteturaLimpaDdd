using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;

namespace ArqLimpaDDD.Domain.Filter;

public class UserFilter : ICustomQueryable
{
    [QueryOperator(Operator = WhereOperator.Contains, CaseSensitive = false)]
    public string? Name { get; set; }

    [QueryOperator(Operator = WhereOperator.Contains, CaseSensitive = false)]
    public string? FullName { get; set; }
}
