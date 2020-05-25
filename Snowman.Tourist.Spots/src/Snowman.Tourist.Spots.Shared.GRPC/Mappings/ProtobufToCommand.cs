using Google.Protobuf;
using Snowman.Tourist.Spots.Shared.Domain.Commands;

namespace Snowman.Tourist.Spots.Shared.GRPC.Mappings
{
    public abstract class ProtobufToCommand<TProtobuf, TCommand> where TProtobuf : IMessage<TProtobuf> where TCommand : Command
    {
        public abstract TCommand Mapper(TProtobuf protobuf);
    }
}
