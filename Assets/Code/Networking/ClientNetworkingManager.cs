using CopperStudios.Tools;
using Mirror;
using UnityEngine;

namespace Code.Networking
{
    public class ClientNetworkingManager : SingletonMonoBehaviour<ClientNetworkingManager>
    {
        [SerializeField] private NetworkManager manager;
        [SerializeField] private ulong currentJoinCode;

        private bool isHost;
        private bool isClient;

        public ulong GetCurrentJoinCode() => currentJoinCode;

        public void StartHost()
        {
            StopNetworking();

            manager.StartHost();
            isHost = true;

            currentJoinCode = StartSteamLobby();
        }

        public void StartClient(ulong code)
        {
            StopNetworking();

            manager.networkAddress = code.ToString();
            manager.StartClient();
            isClient = true;
        }

        public void StopNetworking()
        {
            if (isHost)
                manager.StopHost();
            if (isClient)
                manager.StopClient();
        }

        // TODO: Implement creating a steam lobby and returning the lobby join code
        public ulong StartSteamLobby()
        {
            return (ulong)Random.Range(0, 1000000000000);
        }
    }
}