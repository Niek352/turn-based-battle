using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Character
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        [SerializeField] private Image hpBar;
        private float currentHealth;
        public Action onCharacterDied;
        
        public void Init(float health)
        {
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
            onCharacterDied?.Invoke();
        }

        private void UpdateUI()
        {
            hpBar.fillAmount = 1f / maxHealth * currentHealth;
        }
    }
}