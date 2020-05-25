using Grpc.Net.Client;
using System;

namespace Snowman.Tourist.Spots.Shared.GRPCClient
{
    public interface IClient : IDisposable
    {
        string ServerGRPC { get; }
        GrpcChannel Channel { get; }
    }
}
