using System;
using System.Collections.Generic;
using System.Linq;
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
        [SerializeField] private AIInput aiInput;
        [SerializeField] private EndScreen endScreen; 
        private BattleState currentBattleState;
        public BattleState CurrentCurrentBattleState => currentBattleState;

        private EnemyCharacter[] enemyCharacters;
        private BaseCharacter[] playerCharacters;
        private Battle battle;

        public void StartBattle(BaseCharacter[] allCharacters,Battle battle)
        {
            this.battle = battle;
            playerCharacters = allCharacters.Where(character => character.IsEnemy == false).ToArray();
            enemyCharacters = allCharacters.Where(character => character.IsEnemy).Select(character => character as EnemyCharacter).ToArray();
            
            picker.Init(enemyCharacters, playerCharacters);
            aiInput.Init(enemyCharacters);
            
            BaseAbility.onEndTurn += OnEndTurn;
            BaseAbility.onAbilityUsed += OnAbilityUsed;
            var turn = BattleState.PlayerTurn;
            ChangeState(turn);
        }



        private void OnDestroy()
        {
            BaseAbility.onEndTurn -= OnEndTurn;
        }
        
        private void OnAbilityUsed()
        {
            switch (currentBattleState)
            {
                case BattleState.PlayerTurn:
                    PlayerCharacter.CanUseAbility = false;
                    break;
                case BattleState.EnemyTurn:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnEndTurn()
        {
            ChangeState();
        }

        private static BattleState ChooseFirstTurn()
            =>  Random.Range(0, 2) == 0 ? BattleState.PlayerTurn : BattleState.EnemyTurn;

        private void ChangeState()
        {
            if (CheckOnAlive())
            {
                //EndGame
                endScreen.gameObject.SetActive(true);
                return;
            }

            
            
            currentBattleState = currentBattleState == BattleState.EnemyTurn ? BattleState.PlayerTurn : BattleState.EnemyTurn;
            AfterChangedState();
        }

        private bool CheckOnAlive()
        {
            if (enemyCharacters.Count(character => character.IsAlive) == 0)
            {
                //Player Win;
                endScreen.ShowScreen(battle,true);
                return true;
            }
            else if(playerCharacters.Count(character => character.IsAlive) == 0)
            {
                //Player LOOSe
                endScreen.ShowScreen(battle,false);
                return true;
            }

            return false;
        }

        private void ChangeState(BattleState state)
        {
            currentBattleState = state;
            AfterChangedState();
        }

        private void AfterChangedState()
        {
            switch (currentBattleState)
            {
                case BattleState.PlayerTurn:
                    PlayerCharacter.CanUseAbility = true;
                    
                    break;
                
                case BattleState.EnemyTurn:
                    aiInput.DoAction();
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        
        
        public enum BattleState
        {
            PlayerTurn,
            EnemyTurn,
        }
    }
}

