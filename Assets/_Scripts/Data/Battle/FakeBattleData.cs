using System;
using _Scripts.Character;
using UnityEngine;

namespace _Scripts.Data.Battle
{
    [CreateAssetMenu(fileName = "BattleData", menuName = "data/Battle data")]
    public class FakeBattleData : ScriptableObject
    {
        [SerializeField] private BattleData battleData;
        [SerializeField] private CharacterData baseData;
        public BattleData BattleData => battleData;
        public CharacterData CharacterData => baseData;
    }

    [Serializable]
    public struct BattleData
    {
        [SerializeField] private PlayerCharacter[] playerCharacters;
        [SerializeField] private EnemyCharacter[] enemyCharacters;

        public BattleData(PlayerCharacter[] playerCharacters,EnemyCharacter[] enemyCharacters)
        {
            this.playerCharacters = playerCharacters;
            this.enemyCharacters = enemyCharacters;
        }

        public PlayerCharacter[] PlayerCharacters => playerCharacters;
        public EnemyCharacter[] EnemyCharacters => enemyCharacters;
    }
}
