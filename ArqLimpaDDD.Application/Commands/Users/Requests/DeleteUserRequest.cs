using ArqLimpaDDD.Domain.Messages;

namespace ArqLimpaDDD.Application.Commands.Users.Requests;

public class DeleteUserRequest : Command
{
    public DeleteUserRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }

    public override bool IsValid()
    {
        return Guid.Empty != Id;
    }
}