using MediatR;
using Snowman.Tourist.Spots.Shared.Domain.Messages;

namespace Snowman.Tourist.Spots.Shared.Domain.Events
{
    public abstract class Event : Message, INotification
    {
    }
}
