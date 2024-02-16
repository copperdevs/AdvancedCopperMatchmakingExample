using Code.Networking;
using CopperMatchmaking.Client;
using Riptide;
using UnityEngine.SceneManagement;

namespace CopperMatchmaking.Example.Client
{
    public class PlayerClientHandler : IClientHandler
    {
        public ulong ClientRequestedToHost()
        {
            ClientNetworkingManager.Instance.StartHost();
            return ClientNetworkingManager.Instance.GetCurrentJoinCode();
        }

        public void JoinServer(ulong serverJoinCode)
        {
            ClientNetworkingManager.Instance.StartClient(serverJoinCode);   
        }

        public void Disconnected(DisconnectReason reason)
        {
            ClientNetworkingManager.Instance.StopNetworking();
            SceneManager.LoadScene(0);
        }
    }
}