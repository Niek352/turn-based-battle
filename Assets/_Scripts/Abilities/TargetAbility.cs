using _Scripts.Character;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Abilities
{
    public abstract class TargetAbility : BaseAbility
    {
        [SerializeField] private TargetType targetType;

        protected sealed override void UseAbility() { }

        protected abstract void UseAbilityOnTarget(BaseCharacter user,BaseCharacter target);
        
        public sealed override void OnClick(BaseCharacter user)
        {
            WaitTargetOnClick(user);
        }
    
        private void WaitTargetOnClick(BaseCharacter user)
        {
            TargetPicker.Instance.GetTargetWithWaiting(user, targetType,target =>
            {
                
                OnAbilityUsed();
                DoAnimation(user,()=>
                {
                    UseAbilityOnTarget(user, target);
                    EndTurn();
                },target);
            });
        }
    }
}