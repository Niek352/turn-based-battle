using System;
using _Scripts.Character;
using Spine.Unity;
using UnityEngine;

namespace _Scripts.Abilities
{
    public abstract class BaseAbility : ScriptableObject
    {
        [Header("Base")] [SerializeField] private Sprite abilitySprite;
        [SerializeField] private string abilityText;

        public string animationName; 
        public Sprite AbilitySprite => abilitySprite;
        public string AbilityText => abilityText;

        public static Action onEndTurn;
        public static Action onAbilityUsed;
        

        protected abstract void UseAbility();

   
        public virtual void OnClick(BaseCharacter user)
        {
            UseAbility();
            OnAbilityUsed();
            DoAnimation(user, EndTurn);
        }

        protected virtual void DoAnimation(BaseCharacter user, Action endTurn, params BaseCharacter[] targets)
        {
            if (string.IsNullOrEmpty(animationName))
                return;
            
            AbilityAnimator.Instance.DoAnimation(
                user,
                () =>
                {
                    user.CharacterAnimation.TriggerAnimation(animationName,endTurn);
                },
                targets);
        }

        protected void OnAbilityUsed()
        {
            onAbilityUsed?.Invoke();
        }

        protected void EndTurn()
        {
            AbilityAnimator.Instance.MoveBack(onEndTurn);
        } 
    }
}