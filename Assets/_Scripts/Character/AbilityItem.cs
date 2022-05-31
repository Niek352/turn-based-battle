using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Scripts.Character
{
    public class AbilityItem : MonoBehaviour, IPointerClickHandler
    {
        private Image abilityImg;
        private TMP_Text abilityTxt;
        private BaseAbility baseAbility;
        private bool stateIsActive;
        
        public void Init(Sprite abilitySprite, string abilityText, BaseAbility baseAbility)
        {
            abilityImg.sprite = abilitySprite;
            abilityTxt.text = abilityText;
            this.baseAbility = baseAbility;
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (stateIsActive)
            {
                StopCoroutine(baseAbility.WaitTargetOnClick());
                stateIsActive = false;
                abilityImg.color = Color.white;
            }
            else
            {
                StartCoroutine(baseAbility.WaitTargetOnClick());
                stateIsActive = false;
                abilityImg.color = Color.red;
            }
        }
    }
}