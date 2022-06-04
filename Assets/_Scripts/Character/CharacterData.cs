using _Scripts.Abilities;
using UnityEngine;

namespace _Scripts.Character
{
    [CreateAssetMenu(menuName = "CharacterData", fileName = "CharacterData")]
    public class CharacterData : ScriptableObject
    {
        [Header("CharacterData")]
        [SerializeField] private float maxHealth;
        [SerializeField] private BaseAbility[] abilities;
        public BaseAbility[] Abilities => abilities;
        public float MaxHealth => maxHealth;
    }
}