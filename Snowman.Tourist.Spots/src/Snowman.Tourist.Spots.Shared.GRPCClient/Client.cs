using Grpc.Net.Client;
using System;

namespace Snowman.Tourist.Spots.Shared.GRPCClient
{
    public sealed class Client : IClient
    {
        public Client(string serverGRPC)
        {
            ServerGRPC = serverGRPC;
            if (!ServerGRPC.StartsWith("https"))
            {
                AppContext.SetSwitch(
                    "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            }

            Channel = GrpcChannel.ForAddress(ServerGRPC);
        }
        public string ServerGRPC { get; }

        public GrpcChannel Channel { get; }

        public void Dispose() => Channel.Dispose();
    }
}
