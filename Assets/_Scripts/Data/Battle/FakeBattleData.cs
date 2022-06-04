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
        [SerializeField] private BaseCharacter[] playerCharacters;
        [SerializeField] private BaseCharacter[] enemyCharacters;

        public BattleData(BaseCharacter[] playerCharacters,BaseCharacter[] enemyCharacters)
        {
            this.playerCharacters = playerCharacters;
            this.enemyCharacters = enemyCharacters;
        }

        public BaseCharacter[] PlayerCharacters => playerCharacters;
        public BaseCharacter[] EnemyCharacters => enemyCharacters;
    }
}
