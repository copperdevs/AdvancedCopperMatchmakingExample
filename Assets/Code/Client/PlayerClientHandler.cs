using Code.Networking;
using CopperMatchmaking.Client;
using Riptide;
using UnityEngine.SceneManagement;

namespace CopperMatchmaking.Example.Client
{
    public class PlayerClientHandler : IClientHandler
    {
        public string ClientRequestedToHost()
        {
            ClientNetworkingManager.Instance.StartHost();
            return ClientNetworkingManager.Instance.GetCurrentJoinCode();
        }

        public void JoinServer(string serverJoinCode)
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