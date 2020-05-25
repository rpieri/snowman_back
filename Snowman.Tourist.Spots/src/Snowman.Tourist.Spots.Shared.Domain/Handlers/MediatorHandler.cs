using MediatR;
using Snowman.Tourist.Spots.Shared.Domain.Commands;
using Snowman.Tourist.Spots.Shared.Domain.Events;
using Snowman.Tourist.Spots.Shared.Domain.Interfaces;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Shared.Domain.Handlers
{
    internal sealed class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator mediator;

        public MediatorHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : Event
        {
            await Task.Yield();
            await mediator.Publish(@event);
        }

        public async Task<CommandResult> SendAsync<TCommand>(TCommand command) where TCommand : IRequest<CommandResult> => await mediator.Send(command);
    }
}
