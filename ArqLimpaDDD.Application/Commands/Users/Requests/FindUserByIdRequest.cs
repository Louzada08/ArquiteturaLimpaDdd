using MediatR;

namespace ArqLimpaDDD.Application.Commands.Users.Requests;

public class FindUserByIdRequest : IRequest<FindUserByIdResponse>
{
    public Guid Id { get; set; }
}