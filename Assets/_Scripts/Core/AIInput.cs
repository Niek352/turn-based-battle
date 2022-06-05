using System;
using System.Linq;
using _Scripts.Character;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Core
{
    public class AIInput : MonoBehaviour
    {
        private EnemyCharacter[] characters;

        public void Init(EnemyCharacter[] characters)
        {
            this.characters = characters;
        }

        public void DoAction()
        {
            var randChar = GetRandomCharacter();
            
            Observable
                .Timer(TimeSpan.FromSeconds(2f))
                .TakeUntilDisable(this)
                .Subscribe(l =>
                {
                    randChar.DoAction();
                });
        }

        private EnemyCharacter GetRandomCharacter()
        {
            var aliveChars = characters.Where(character => character.IsAlive).ToArray();
                return aliveChars[Random.Range(0, aliveChars.Length)];
        }
    }
}