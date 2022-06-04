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
            BattleSystem.Instance.StartBattle(characters.ToArray());
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
                
                character.Init(isEnemy,BattleSceneData.Instance.AbilityGenerator,battleData.CharacterData);
                characters.Add(character);
            }
        }
    }
}
