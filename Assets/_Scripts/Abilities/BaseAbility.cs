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

        public static Action onAbilityUsed;
        

        protected abstract void UseAbility();

   
        public virtual void OnClick(BaseCharacter character)
        {
            UseAbility();
            DoAnimation(character, EndTurn);
        }

        protected virtual void DoAnimation(BaseCharacter character, Action callback)
        {
            character.CharacterAnimation.TriggerAnimation(animationName,callback);
        } 

        protected void EndTurn()
        {
            onAbilityUsed?.Invoke();
        } 
    }
}