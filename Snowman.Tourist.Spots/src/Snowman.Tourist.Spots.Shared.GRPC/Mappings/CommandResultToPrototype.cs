using Google.Protobuf;
using Snowman.Tourist.Spots.Shared.Domain.Commands;

namespace Snowman.Tourist.Spots.Shared.GRPC.Mappings
{
    public abstract class CommandResultToPrototype<TProtobuf> where TProtobuf : IMessage<TProtobuf>
    {
        public abstract TProtobuf Mapper(CommandResult commandResult);
    }
}
