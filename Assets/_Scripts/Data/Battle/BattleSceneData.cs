using _Scripts.Abilities;
using _Scripts.Character;
using _Scripts.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Data.Battle
{
    public class BattleSceneData : Singleton<BattleSceneData>
    {
        [SerializeField] private Transform[] playerCharactersPositions;
        [SerializeField] private Transform[] enemyCharactersPositions;

        [SerializeField] private AbilityGenerator abilityGenerator;

        public Transform[] PlayerCharactersPositions => playerCharactersPositions;
        public Transform[] EnemyCharactersPositions => enemyCharactersPositions;
        public AbilityGenerator AbilityGenerator => abilityGenerator;
    }
}
