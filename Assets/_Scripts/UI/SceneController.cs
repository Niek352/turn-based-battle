using _Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private Button playBtn;
        [SerializeField] private Button exitBtn;
        [SerializeField] private BattleInitializer battleInitializer;
    
        private void Awake()
        {
            playBtn.onClick.AddListener(StartGame);
            exitBtn.onClick.AddListener(ExitFromGame);
        }


        private void ExitFromGame()
        {
            Application.Quit();
        }
        private void StartGame()
        {
            battleInitializer.InitBattle();
        }
    }
}
