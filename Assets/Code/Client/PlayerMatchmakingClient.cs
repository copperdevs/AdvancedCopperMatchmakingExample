#nullable enable
using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using CopperMatchmaking.Client;
using CopperMatchmaking.Data;
using CopperMatchmaking.Info;
using UnityEngine;

namespace CopperMatchmaking.Example.Client
{
    public class PlayerMatchmakingClient : MonoBehaviour
    {
        private MatchmakerClient? client;
        
        private ulong playerId;
        private Rank playerRank;

        private void Start()
        {
            playerId = PlayerInfoHolder.Instance.GetPlayerId();   
            playerRank = PlayerInfoHolder.Instance.GetPlayerRank();   
            
            client = new MatchmakerClient("127.0.0.1", new PlayerClientHandler(), playerRank, playerId);
        }

        private void FixedUpdate()
        {
            try
            {
                client?.Update();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}