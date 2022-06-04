using _Scripts.Character;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Abilities
{
    public abstract class TargetAbility : BaseAbility
    {
        [SerializeField] private TargetType targetType;

        protected sealed override void UseAbility() { }

        protected abstract void UseAbilityOnTarget(BaseCharacter baseCharacter);
        
        public sealed override void OnClick(BaseCharacter character)
        {
            WaitTargetOnClick(character);
        }
    
        private void WaitTargetOnClick(BaseCharacter character)
        {
            TargetPicker.Instance.GetTargetWithWaiting(targetType,baseCharacter =>
            {
                UseAbilityOnTarget(baseCharacter);
                DoAnimation(character, EndTurn);
            });
        }
    }
}