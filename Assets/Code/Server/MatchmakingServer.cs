using System;
using CopperMatchmaking.Data;
using CopperMatchmaking.Example.Data;
using CopperMatchmaking.Info;
using UnityEngine;
using CopperMatchmaking.Server;
using Riptide;
using Riptide.Transports.Tcp;
using Riptide.Utils;

namespace CopperMatchmaking.Example.Server
{
    public class MatchmakingServerExample : MonoBehaviour
    {
        [SerializeField] private MatchmakingRanks ranks;
        [SerializeField] private string serverIp = "127.0.0.1:7777";
        
        private MatchmakerServer server;

        private Riptide.Client riptideClient;
        
        private void Start()
        {
            CopperLogger.Initialize(Debug.Log, Debug.LogWarning, Debug.LogError);
            RiptideLogger.Initialize(Log.Info, Log.Info, Log.Warning, Log.Error, false);
            
            DontDestroyOnLoad(this);
            
            LoadServer();
        }

        private void LoadServer()
        {
            // we use a normal riptide client to check if the local server is up, if so, we dont want ours
            riptideClient = new Riptide.Client(new TcpClient(), "CONNECTION TEST CLIENT");
            
            riptideClient.Connected += RiptideClientConnected;
            riptideClient.Disconnected += RiptideClientDisconnected;
            riptideClient.ConnectionFailed += RiptideClientDisconnected;
            
            riptideClient.Connect(serverIp);
        }
        
        private void RiptideClientConnected(object sender, EventArgs eventArgs)
        {
            Destroy(this.gameObject);
        }

        private void RiptideClientDisconnected(object sender, DisconnectedEventArgs disconnectedEventArgs)
        {
            Log.Info($"Starting local matchmaker server");
            server = new MatchmakerServer(new ServerHandler(), 4);
            server.RegisterRanks(ranks.ranks.ToArray());
        }
        
        private void RiptideClientDisconnected(object sender, ConnectionFailedEventArgs e)
        {
            RiptideClientDisconnected(sender, new DisconnectedEventArgs(DisconnectReason.ConnectionRejected, null));
        }
        
        private void Update()
        {
            server?.Update();
            riptideClient?.Update();
        }
    }
}