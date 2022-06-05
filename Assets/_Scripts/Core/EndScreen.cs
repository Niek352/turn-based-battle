using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Core
{
    public class EndScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text msgText;
        [SerializeField] private Button mainMenu;

        private void LoadMenu(Battle battle, bool winPlayer)
        {
            battle.EndBattle(new Battle.EndBattleData(winPlayer));
        }

        public void ShowScreen(Battle battle, bool winPlayer)
        {
            msgText.text = winPlayer ? "Player Win" : "Player Loose";
            mainMenu.onClick.AddListener(() => LoadMenu(battle, winPlayer));
        }
    }
}