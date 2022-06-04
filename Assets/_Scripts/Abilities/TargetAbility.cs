using _Scripts.Character;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Abilities
{
    public abstract class TargetAbility : BaseAbility
    {
        [SerializeField] private TargetType targetType;

        protected abstract void UseAbility(BaseCharacter target);

        public sealed override void OnClick()
        {
            WaitTargetOnClick();
        }
    
        private void WaitTargetOnClick()
        {
            TargetPicker.Instance.GetTargetWithWaiting(targetType, UseAbility);
        }
    }
}