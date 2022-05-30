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
            SceneManager.LoadScene(BattleSceneName);
        }
    }
}
