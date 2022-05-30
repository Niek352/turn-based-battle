using _Scripts.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Data.Battle
{
    public class BattleSceneData : Singleton<BattleSceneData>
    {
        [SerializeField] private Transform[] playerCharactersPositions;
        [SerializeField] private Transform[] enemyCharactersPositions;

        [SerializeField] private Button attackBtn;
        [SerializeField] private Button waitBtn;

        public Transform[] PlayerCharactersPositions => playerCharactersPositions;
        public Transform[] EnemyCharactersPositions => enemyCharactersPositions;
        public Button AttackBtn => attackBtn;
        public Button WaitBtn => waitBtn;
    }
}
