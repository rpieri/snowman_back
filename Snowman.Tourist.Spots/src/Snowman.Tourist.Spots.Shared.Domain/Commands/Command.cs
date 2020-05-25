using MediatR;
using Snowman.Tourist.Spots.Shared.Domain.Messages;

namespace Snowman.Tourist.Spots.Shared.Domain.Commands
{
    public abstract class Command : Message, IRequest<CommandResult>
    {
    }
}
