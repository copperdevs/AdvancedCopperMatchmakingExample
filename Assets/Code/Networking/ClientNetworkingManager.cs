using System;
using System.Globalization;
using CopperMatchmaking.Info;
using CopperStudios.Tools;
using Mirror;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Networking
{
    public class ClientNetworkingManager : SingletonMonoBehaviour<ClientNetworkingManager>
    {
        [SerializeField] private NetworkManager manager;
        [SerializeField] private string currentJoinCode;

        private bool isHost;
        private bool isClient;

        public string GetCurrentJoinCode() => currentJoinCode;

        private void Start()
        {
            CopperLogger.Initialize(Debug.Log, Debug.LogWarning, Debug.LogError);
        }

        public void StartHost()
        {
            StopNetworking();

            manager.StartHost();
            isHost = true;

            currentJoinCode = manager.networkAddress;
        }

        public void StartClient(string code)
        {
            StopNetworking();

            manager.networkAddress = code;
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
        public string StartSteamLobby()
        {
            return $"{Random.Range(0, 1000000000000)}";
        }
    }
}