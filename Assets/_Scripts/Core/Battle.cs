using System.Collections;
using System.Collections.Generic;
using _Scripts.Character;
using _Scripts.Data.Battle;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.Core
{
    public class Battle : MonoBehaviour
    {
        private FakeBattleData battleData;
        private const string BattleSceneName = "Battle";

        private EndBattleData endBattleData;
        
        public void Init(FakeBattleData battleData)
        {
            this.battleData = battleData;
            StartCoroutine(GenerateLevel());
        }

        private IEnumerator GenerateLevel()
        {
            var operation = SceneManager.LoadSceneAsync(BattleSceneName);
            while (operation.isDone == false)
            {
                yield return null;
            }
            GenerateCharacters(out List<BaseCharacter> characters);
            //SubscribeButtons
            BattleSystem.Instance.StartBattle(characters.ToArray(),this);
        }

        private void GenerateCharacters(out List<BaseCharacter> characters)
        {
            characters = new List<BaseCharacter>();

            GenerateCharacter(
                ref characters,
                battleData.BattleData.PlayerCharacters, 
                BattleSceneData.Instance.PlayerCharactersPositions,
                false);
            
            GenerateCharacter(
                ref characters, 
                battleData.BattleData.EnemyCharacters,
                BattleSceneData.Instance.EnemyCharactersPositions, 
                true);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void GenerateCharacter(
            ref List<BaseCharacter> characters, 
            IReadOnlyList<BaseCharacter> battleCharactersData, 
            IReadOnlyList<Transform> characterRoots,
            bool isEnemy)
        {
            for (var index = 0; index < battleCharactersData.Count; index++)
            {
                var character =
                    Instantiate(battleCharactersData[index],characterRoots[index],
                        false);
                
                character.Init(isEnemy,battleData.CharacterData);
                characters.Add(character);
            }
        }

        public void EndBattle(EndBattleData battleData)
        {
            endBattleData = battleData;
            SceneManager.LoadScene(0);
            //Save Data
            Destroy(this);
        }
        
        public struct EndBattleData
        {
            private bool playerWin;

            public EndBattleData(bool playerWin)
            {
                this.playerWin = playerWin;
            }
        }
    }
}
