using _Scripts.Data.Battle;
using UnityEngine;

namespace _Scripts.Core
{
    public class BattleInitializer : MonoBehaviour
    {
        [SerializeField] private BattleData battleData;
        [SerializeField] private Battle battle;
        public void StartBattle()
        {
            var newBattle = Instantiate(battle);
            newBattle.Init(battleData);
            DontDestroyOnLoad(newBattle.gameObject);
        }
    }
}