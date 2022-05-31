using System.Collections;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Character
{
    public abstract class BaseAbility : ScriptableObject
    {
        [SerializeField] private Sprite abilitySprite;
        [SerializeField] private string abilityText;
        
        [SerializeField] private BaseCharacter character;
        [SerializeField] private TargetType targetType;

        protected abstract void UseAbility(BaseCharacter target);
       

        public IEnumerator WaitTargetOnClick()
        {
            yield return TargetPicker.Instance.GetTarget(targetType, baseCharacter =>
            {
                if (baseCharacter)
                {
                    UseAbility(baseCharacter);
                }
            });
        }
    }
}