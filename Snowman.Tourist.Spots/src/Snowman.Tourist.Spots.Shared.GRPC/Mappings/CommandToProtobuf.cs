using Google.Protobuf;
using Snowman.Tourist.Spots.Shared.Domain.Commands;

namespace Snowman.Tourist.Spots.Shared.GRPC.Mappings
{
    public abstract class CommandToProtobuf<TCommand, TProtobuf> where TCommand : Command where TProtobuf : IMessage<TProtobuf>
    {
        public abstract TProtobuf Mapper(TCommand command);
    }
}
