using ArqLimpaDDD.Domain.Messages;
using ArqLimpaDDD.Domain.Validation;

namespace ArqLimpaDDD.Domain.Mediator.Interfaces;

public interface IMediatorHandler
{
    public Task PublishEvent<T>(T evnt) where T : Event;
    public Task<ValidationResultBag> SendCommand<T>(T command) where T : Command;
}
