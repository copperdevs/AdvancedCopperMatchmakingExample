using System;
using CopperMatchmaking.Client;
using UnityEngine;

namespace CopperMatchmaking.Example.Client
{
    public class PlayerMatchmakingClient : MonoBehaviour
    {
        private MatchmakerClient client;

        private void Start()
        {
            client = new MatchmakerClient("127.0.0.0", new PlayerClientHandler(), PlayerInfoHolder.Instance.GetPlayerRank(), PlayerInfoHolder.Instance.GetPlayerId());
        }

        private void FixedUpdate()
        {
            if (client.ShouldUpdate)
                client.Update();
        }
    }
}