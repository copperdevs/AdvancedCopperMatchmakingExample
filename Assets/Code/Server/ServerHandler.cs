using CopperMatchmaking.Data;
using CopperMatchmaking.Server;

namespace CopperMatchmaking.Example.Server
{
    public class ServerHandler : IServerHandler
    {
        public bool VerifyPlayer(ConnectedClient client)
        {
            return true;
        }
    }
}