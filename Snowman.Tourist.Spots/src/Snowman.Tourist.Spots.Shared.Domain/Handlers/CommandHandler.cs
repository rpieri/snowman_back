using MediatR;
using Snowman.Tourist.Spots.Shared.Domain.Commands;
using Snowman.Tourist.Spots.Shared.Domain.Events;
using Snowman.Tourist.Spots.Shared.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Shared.Domain.Handlers
{
    public abstract class CommandHandler<TCommand> : IRequestHandler<TCommand, CommandResult> where TCommand : Command
    {
        private readonly IMediatorHandler mediator;

        public CommandHandler(IMediatorHandler mediator)
        {
            this.mediator = mediator;
        }
        protected Task<CommandResult> CreateCommandResult(bool success) => Task.FromResult(new CommandResult(success));
        protected Task<CommandResult> CreateCommandResult(bool success, string message) => Task.FromResult(new CommandResult(success, message));
        protected Task<CommandResult> CreateCommandResult(bool success, object data) => Task.FromResult(new CommandResult(success, data));
        protected Task<CommandResult> CreateCommandResult(bool success, string message, object data) => Task.FromResult(new CommandResult(success, data, message));
        public abstract Task<CommandResult> Handle(TCommand request, CancellationToken cancellationToken);

        protected async Task PublishEventAsync(Event @event) => await mediator.PublishAsync(@event);
        protected async Task<CommandResult> SendCommandAsync(Command command) => await mediator.SendAsync(command);
    }
}
