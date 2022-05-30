using UnityEngine;

namespace _Scripts.Data.Battle
{
    [CreateAssetMenu(fileName = "BattleData", menuName = "data/Battle data")]
    public class BattleData : ScriptableObject
    {
        [SerializeField] private Character.BaseCharacter[] playerCharacters;
        [SerializeField] private Character.BaseCharacter[] enemyCharacters;
    }
}
