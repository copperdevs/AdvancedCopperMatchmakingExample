using System.Collections.Generic;
using CopperMatchmaking.Data;
using UnityEngine;

namespace CopperMatchmaking.Example.Data
{
    [CreateAssetMenu(fileName = "New Matchmaking Ranks", menuName = "Matchmaking Ranks", order = 0)]
    public class MatchmakingRanks : ScriptableObject
    {
        public List<Rank> ranks;
    }
}