using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Character;
using _Scripts.Utilities;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Core
{
    public class TargetPicker : Singleton<TargetPicker>
    {
        [SerializeField] private BaseCharacter[] enemyCharacters;
        [SerializeField] private BaseCharacter[] playerCharacters;

        private CompositeDisposable disposables = new CompositeDisposable(); 
        public void Init(BaseCharacter[] allCharacters)
        {
            enemyCharacters = allCharacters.Where(character => character.IsEnemy).ToArray();
            playerCharacters = allCharacters.Where(character => character.IsEnemy == false).ToArray();
        }

        public void Dispose()
            => disposables?.Dispose();

        public void GetTargetWithWaiting(TargetType targetType, Action<BaseCharacter> onTargetAdded)
        {
            disposables?.Dispose();
            disposables = new CompositeDisposable();
            switch (targetType)
            {
                case TargetType.Player:
                    WaitTargetTo(playerCharacters, onTargetAdded);
                    break;
                case TargetType.Enemy:
                    WaitTargetTo(enemyCharacters, onTargetAdded);
                    break;
                
                case TargetType.AllPlayer:
                case TargetType.AllEnemy:
                case TargetType.All:
                case TargetType.OnlySelf:
                default:
                    throw new ArgumentOutOfRangeException(nameof(targetType), targetType, null);
            }
        }

        private void WaitTargetTo(BaseCharacter[] characters,Action<BaseCharacter> onTargetAdded)
        {
            foreach (var character in characters)
            {
                character.CharacterHover.Hover();
                character
                    .OnMouseDownAsObservable()
                    .Finally(() =>
                    {
                        character.CharacterHover.StopHover();
                    })
                    .Subscribe(_ =>
                    {
                        onTargetAdded?.Invoke(character);
                        disposables?.Dispose();
                    })
                    .AddTo(disposables);
            }
        }
    }
}