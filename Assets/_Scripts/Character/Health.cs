using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Character
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private Image hpBar;
        [SerializeField] private GameObject blood;
        private float currentHealth;
        public bool IsAlive => currentHealth > 0;
        //public static Action<BaseCharacter> onCharacterDied;
        private BaseCharacter character;
        
        public void Init(BaseCharacter character, float health)
        {
            this.character = character;
            maxHealth = health;
            currentHealth = maxHealth;
        }
        
        public void GetDamage(float value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value),value,"value cant be < 0");

            currentHealth -= value;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            UpdateUI();
            
            if (currentHealth == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            blood.SetActive(true);
            character.CharacterAnimation.StopAnim();
            //onCharacterDied(character);
        }

        private void UpdateUI()
        {
            hpBar.fillAmount = 1f / maxHealth * currentHealth;
        }
    }
}