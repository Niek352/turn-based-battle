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
        public void Init(BaseCharacter[] enemyCharacters,BaseCharacter[] playerCharacters)
        {
            this.enemyCharacters = enemyCharacters;
            this.playerCharacters = playerCharacters;
        }

        public void Dispose()
            => disposables?.Dispose();

        public void GetTargetWithWaiting(BaseCharacter character,TargetType targetType, Action<BaseCharacter> onTargetPicked)
        {
            if (character.IsEnemy)
            {
                FindRandomPlayer(targetType, onTargetPicked);
            }
            else
            {
                WaitPlayerClick(targetType, onTargetPicked);
            }

        }

        private void WaitPlayerClick(TargetType targetType, Action<BaseCharacter> onTargetPicked)
        {
            disposables?.Dispose();
            disposables = new CompositeDisposable();
            switch (targetType)
            {
                case TargetType.One:
                    WaitTargetTo(enemyCharacters, onTargetPicked);
                    break;

                case TargetType.All:
                case TargetType.OnlySelf:
                default:
                    throw new ArgumentOutOfRangeException(nameof(targetType), targetType, null);
            }
        }


        private void FindRandomPlayer(TargetType targetType, Action<BaseCharacter> onTargetPicked)
        {
            switch (targetType)
            {
                case TargetType.One:
                    onTargetPicked.Invoke(GetRandomAlivePlayer(playerCharacters));
                    break;

                case TargetType.All:
                case TargetType.OnlySelf:
                default:
                    throw new ArgumentOutOfRangeException(nameof(targetType), targetType, null);
            }
        }

        private BaseCharacter GetRandomAlivePlayer(BaseCharacter[]characters)
        {
            var aliveChars = characters.Where(character => character.IsAlive).ToArray();
            return aliveChars[Random.Range(0, aliveChars.Length)];
        }

        private void WaitTargetTo(BaseCharacter[] characters,Action<BaseCharacter> onTargetAdded)
        {
            foreach (var character in characters.Where(character => character.IsAlive))
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