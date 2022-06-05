using System;
using System.Collections.Generic;
using _Scripts.Character;
using _Scripts.Core;
using _Scripts.Utilities;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace _Scripts.Abilities
{
    public class AbilityAnimator : Singleton<AbilityAnimator>
    {
        [SerializeField] private SpriteRenderer blurScreen;
        
        [SerializeField] private Transform playerPosition;
        [SerializeField] private Transform enemyPosition;

        private List<BaseCharacter> cashedCharacters = new List<BaseCharacter>();

        private float Duration => .75f;
        
        public void DoAnimation(BaseCharacter user,Action callback, params BaseCharacter[] targets)
        {
            if (cashedCharacters.Count != 0)
                throw new ArgumentException("cashedCharacter wasnt clear");
                
            cashedCharacters.AddRange(targets);
            cashedCharacters.Add(user);
            
            MoveCharacters(user, targets);
            blurScreen.DOFade(.5f, Duration)
                .OnComplete(() =>
                {
                    callback?.Invoke();
                });
        }

        public void MoveBack(Action onComplete)
        {
            if (cashedCharacters.Count == 0)
                return;
            
            foreach (var cashedCharacter in cashedCharacters)
            {
                cashedCharacter.transform.DOMove(cashedCharacter.InitPosition, 0.75f);
            }
            blurScreen.DOFade(0,.75f).OnComplete(onComplete.Invoke);
            
            cashedCharacters.Clear();
        }


        private void MoveCharacters(BaseCharacter user, BaseCharacter[] targets)
        {
            switch (BattleSystem.Instance.CurrentCurrentBattleState)
            {
                case BattleSystem.BattleState.PlayerTurn:
                    user.transform.DOMove(playerPosition.position, Duration);
                    foreach (var target in targets)
                    {
                        target.transform.DOMove(enemyPosition.position, Duration);
                    }
                    break;
                
                case BattleSystem.BattleState.EnemyTurn:
                    user.transform.DOMove(enemyPosition.position, Duration);
                    foreach (var target in targets)
                    {
                        target.transform.DOMove(playerPosition.position, Duration);
                    }
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}