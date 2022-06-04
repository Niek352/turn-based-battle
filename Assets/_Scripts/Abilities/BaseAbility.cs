using System;
using _Scripts.Character;
using UnityEngine;

namespace _Scripts.Abilities
{
    public abstract class BaseAbility : ScriptableObject
    {
        [Header("Base")] [SerializeField] private Sprite abilitySprite;
        [SerializeField] private string abilityText;
        private BaseCharacter character;
        public Sprite AbilitySprite => abilitySprite;
        public string AbilityText => abilityText;

        public static Action<BaseCharacter> onAbilityUsed;
        

        protected void UseAbility() { }
        

        public virtual void OnClick() { }

        protected void EndTurn()
        {
            onAbilityUsed?.Invoke(character);
        } 
    }
}