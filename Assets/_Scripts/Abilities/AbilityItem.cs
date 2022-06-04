using _Scripts.Character;
using _Scripts.Core;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Scripts.Abilities
{
    public class AbilityItem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image abilityImg;
        [SerializeField] private TMP_Text abilityTxt;
        private BaseAbility baseAbility;
        private bool stateIsActive;
        private Color cashedColor;
        private BaseCharacter character;
        
        public void Init(BaseCharacter baseCharacter, BaseAbility baseAbility)
        {
            character = baseCharacter;
            cashedColor = abilityImg.color;
            abilityImg.sprite = baseAbility.AbilitySprite;
            abilityTxt.text = baseAbility.AbilityText;
            this.baseAbility = baseAbility;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (stateIsActive)
            {
                TargetPicker.Instance.Dispose();
                stateIsActive = false;
                abilityImg.color = cashedColor;
            }
            else
            {
                baseAbility.OnClick(character);
                stateIsActive = true;
                abilityImg.color = Color.red;
            }
        }
    }
}