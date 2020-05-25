using MediatR;
using Snowman.Tourist.Spots.Shared.Domain.Commands;
using Snowman.Tourist.Spots.Shared.Domain.Events;
using System.Threading.Tasks;

namespace Snowman.Tourist.Spots.Shared.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : Event;
        Task<CommandResult> SendAsync<TCommand>(TCommand command) where TCommand : IRequest<CommandResult>;
    }
}
