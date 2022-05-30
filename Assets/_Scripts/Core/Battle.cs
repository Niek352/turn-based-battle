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
        private BattleData battleData;
        private const string BattleSceneName = "Battle";
        
        public void Init(BattleData battleData)
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
            GenerateCharacters();
        }

        private void GenerateCharacters()
        {
            for (var index = 0; index < battleData.PlayerCharacters.Length; index++)
            {
                var character = 
                    Instantiate(battleData.PlayerCharacters[index], BattleSceneData.Instance.PlayerCharactersPositions[index], false);
                
                character.Init(false);
            }

            for (var index = 0; index < battleData.EnemyCharacters.Length; index++)
            {
                var character = 
                    Instantiate(battleData.PlayerCharacters[index], BattleSceneData.Instance.EnemyCharactersPositions[index], false);
                
                character.Init(true);
                
            }
        }
    }
}
