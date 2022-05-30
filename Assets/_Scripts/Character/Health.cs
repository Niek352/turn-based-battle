using System;
using UnityEngine;

namespace _Scripts.Character
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        private float currentHealth;
        public Action onCharacterDied;
        
        public void Init()
        {
            currentHealth = maxHealth;
        }
        
        public void ApplyDamage(float value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value),value,"value cant be < 0");

            currentHealth -= value;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            if (currentHealth == 0)
            {
                Die();
            }
        }

        private void Die()
        {
            onCharacterDied?.Invoke();
        }

        
    }
}