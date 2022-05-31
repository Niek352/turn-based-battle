using System;
using _Scripts.Character;
using UnityEngine;

namespace _Scripts.Data.Battle
{
    [CreateAssetMenu(fileName = "BattleData", menuName = "data/Battle data")]
    public class BattleData : ScriptableObject
    {
        [SerializeField] private BaseCharacter[] playerCharacters = Array.Empty<BaseCharacter>();
        [SerializeField] private BaseCharacter[] enemyCharacters = Array.Empty<BaseCharacter>();

        public BaseCharacter[] PlayerCharacters => playerCharacters;
        public BaseCharacter[] EnemyCharacters => enemyCharacters;
    }
}
