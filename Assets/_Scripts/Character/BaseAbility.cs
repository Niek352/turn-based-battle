using System.Collections;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Character
{
    public abstract class BaseAbility : ScriptableObject
    {
        [Header("Base")]
        [SerializeField] private Sprite abilitySprite;
        [SerializeField] private string abilityText;
        [SerializeField] private TargetType targetType;
        private BaseCharacter character;
        public Sprite AbilitySprite => abilitySprite;
        public string AbilityText => abilityText;


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