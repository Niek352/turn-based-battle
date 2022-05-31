using System;
using System.Collections.Generic;
using _Scripts.Character;
using _Scripts.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Core
{
    public class BattleSystem : Singleton<BattleSystem>
    {
        [SerializeField] private TargetPicker picker; 
        [SerializeField] private AbilityGenerator abilityGenerator; 
        private Action<BattleState> onStateChanged;
        private BattleState battleState;
        
        public void StartBattle(BaseCharacter[] baseCharacters)
        {
            picker.Init(baseCharacters);
            var turn = ChooseFirstTurn();
            ChangeState(turn);
        }

        private static BattleState ChooseFirstTurn()
        {
            return Random.Range(0, 2) == 0 ? BattleState.PlayerTurn : BattleState.EnemyTurn;
        }

        private void ChangeState(BattleState state)
        {
            battleState = state;
            
            onStateChanged?.Invoke(state);
        }
        
        private enum BattleState
        {
            Wait = 0,
            PlayerTurn,
            EnemyTurn,
        }
    }
}

