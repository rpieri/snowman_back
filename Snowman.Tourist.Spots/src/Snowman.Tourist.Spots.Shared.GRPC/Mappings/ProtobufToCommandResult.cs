using Google.Protobuf;
using Snowman.Tourist.Spots.Shared.Domain.Commands;

namespace Snowman.Tourist.Spots.Shared.GRPC.Mappings
{
    public abstract class ProtobufToCommandResult<TProtobuf> where TProtobuf : IMessage<TProtobuf>
    {
        public abstract CommandResult Mapper(TProtobuf protobuf);
    }
}
