using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Scripts.Character
{
    public class AbilityItem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image abilityImg;
        [SerializeField] private TMP_Text abilityTxt;
        private BaseAbility baseAbility;
        private bool stateIsActive;
        private Color cashedColor;
        
        public void Init(BaseAbility baseAbility)
        {
            cashedColor = abilityImg.color;
            abilityImg.sprite = baseAbility.AbilitySprite;
            abilityTxt.text = baseAbility.AbilityText;
            this.baseAbility = baseAbility;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (stateIsActive)
            {
                StopCoroutine(baseAbility.WaitTargetOnClick());
                stateIsActive = false;
                abilityImg.color = cashedColor;
            }
            else
            {
                StartCoroutine(baseAbility.WaitTargetOnClick());
                stateIsActive = true;
                abilityImg.color = Color.red;
            }
        }
    }
}