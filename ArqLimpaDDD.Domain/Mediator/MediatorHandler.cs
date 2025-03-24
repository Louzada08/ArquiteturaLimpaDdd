using MediatR;
using ArqLimpaDDD.Domain.Mediator.Interfaces;
using ArqLimpaDDD.Domain.Messages;
using ArqLimpaDDD.Domain.Validation;

namespace ArqLimpaDDD.Domain.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<T>(T evnt) where T : Event
        {
            await _mediator.Publish(evnt);
        }

        public async Task<ValidationResultBag> SendCommand<T>(T command) where T : Command
        {
            return await _mediator.Send(command);
        }
    }
}
