using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

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
        print("Start");
        battleInitializer.InitBattle();
    }
}
