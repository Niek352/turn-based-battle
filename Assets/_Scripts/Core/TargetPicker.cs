using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Character;
using _Scripts.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Core
{
    public class TargetPicker : Singleton<TargetPicker>
    {
        [SerializeField] private BaseCharacter[] enemyCharacters;
        [SerializeField] private BaseCharacter[] playerCharacters;

        public void Init(BaseCharacter[] allCharacters)
        {
            enemyCharacters = allCharacters.Where(character => character.IsEnemy).ToArray();
            playerCharacters = allCharacters.Where(character => character.IsEnemy == false).ToArray();
        }

        public void GetTarget()
        {
            
        }
        public IEnumerator GetTarget(TargetType targetType, Action<BaseCharacter> onTargetAdded)
        {
            switch (targetType)
            {
                case TargetType.Player:
                    onTargetAdded(playerCharacters[Random.Range(0, enemyCharacters.Length)]);
                    break;
                case TargetType.Enemy:
                    onTargetAdded(enemyCharacters[Random.Range(0, enemyCharacters.Length)]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(targetType), targetType, null);
            }
            yield return null;
            
        }
    }
}