using System;
using System.Collections.Generic;
using _Scripts.Abilities;
using _Scripts.Character;
using _Scripts.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Core
{
    public class BattleSystem : Singleton<BattleSystem>
    {
        [SerializeField] private TargetPicker picker; 
        private BattleState battleState;
        
        
        public void StartBattle(BaseCharacter[] baseCharacters)
        {
            picker.Init(baseCharacters);

            BaseAbility.onAbilityUsed += OnAbilityUsed;
            
            
            var turn = ChooseFirstTurn();
            ChangeState(turn);
        }

        private void OnDestroy()
        {
            BaseAbility.onAbilityUsed -= OnAbilityUsed;
        }

        private void OnAbilityUsed()
        {
            ChangeState();
        }

        private static BattleState ChooseFirstTurn()
            =>  Random.Range(0, 2) == 0 ? BattleState.PlayerTurn : BattleState.EnemyTurn;
        
        private void ChangeState()
            => battleState = battleState == BattleState.EnemyTurn ? BattleState.PlayerTurn : BattleState.EnemyTurn;
            
        private void ChangeState(BattleState state)
            => battleState = state;
        
        private enum BattleState
        {
            PlayerTurn,
            EnemyTurn,
        }
    }
}

