using System;
using CopperMatchmaking.Data;
using CopperMatchmaking.Example.Data;
using CopperStudios.Tools;
using UnityEngine;
using Random = UnityEngine.Random;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CopperMatchmaking.Example.Client
{
    public class PlayerInfoHolder : SingletonMonoBehaviour<PlayerInfoHolder>
    {
        [SerializeField] private ulong playerId;
        [SerializeField] private PlayerRank rank;

        public ulong GetPlayerId() => playerId;
        public Rank GetPlayerRank() => rank;

        private void Start()
        {
            DontDestroyOnLoad(this);
            playerId = (ulong)Random.Range(0, 1000000000000);
        }

        [Serializable]
        public class PlayerRank
        {
            [SerializeField] private MatchmakingRanks ranks;
            [SerializeField] private int matchmakerRank;
            [SerializeField] private Rank clientRank;

            public static implicit operator Rank(PlayerRank rank)
            {
                if (rank.clientRank != null) return rank.clientRank;
                if(rank.ranks != null) return rank.ranks.ranks[0];
                return new Rank("Unranked", 0);
            }

            public void GetRank()
            {
                clientRank = ranks.ranks[matchmakerRank];
            }

#if UNITY_EDITOR
            [CustomPropertyDrawer(typeof(PlayerRank))]
            public class PlayerRankDrawer : PropertyDrawer
            {
                public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
                {
                    var rankSoSerializedProperty = property.FindPropertyRelative("ranks");
                    var rankSo = (MatchmakingRanks)rankSoSerializedProperty.boxedValue;
                    var rankSoSelected = rankSoSerializedProperty?.boxedValue != null;

                    if (!rankSoSelected)
                    {
                        EditorGUILayout.PropertyField(property.FindPropertyRelative("ranks"));
                    }
                    else
                    {
                        EditorGUI.BeginProperty(position, label, property);

                        EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
                        EditorGUI.indentLevel++;

                        EditorGUILayout.IntSlider(property.FindPropertyRelative("matchmakerRank"), 0, rankSo.ranks.Count - 1);
                        property.FindPropertyRelative("clientRank").boxedValue = rankSo.ranks[property.FindPropertyRelative("matchmakerRank").intValue];
                        EditorGUILayout.LabelField($"Client Rank", rankSo.ranks[property.FindPropertyRelative("matchmakerRank").intValue].DisplayName);

                        EditorGUI.indentLevel--;
                        EditorGUI.EndProperty();
                    }
                }
            }
#endif
        }
    }
}