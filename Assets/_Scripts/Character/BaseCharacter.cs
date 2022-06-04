using System;
using _Scripts.Abilities;
using Spine.Unity;
using UnityEngine;

namespace _Scripts.Character
{
    [RequireComponent(typeof(Health))]
    public class BaseCharacter : MonoBehaviour
    {
        [Header("CharacterData")]
        [SerializeField] private float maxHealth;
        [SerializeField] private BaseAbility[] abilities;
        [Space(10)]
        [Header("Links")]
        [SerializeField] private Health health;
        [SerializeField] private SkeletonAnimation skeletonAnimation;
        [SerializeField] private CharacterHover characterHover;

        private AbilityGenerator abilityGenerator;
        public CharacterHover CharacterHover => characterHover;
        public bool IsEnemy { get; private set; }

        public void Init(bool isEnemy, AbilityGenerator abilityGenerator)
        {
            health.Init(maxHealth);
            this.IsEnemy = isEnemy;
            skeletonAnimation.initialFlipX = isEnemy;
            skeletonAnimation.Initialize(true);
            this.abilityGenerator = abilityGenerator;
        }
        
        private void OnValidate()
        {
            health = GetComponent<Health>();
            skeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
        }

        private void OnMouseDown()
        {
            if (IsEnemy == false)
            {
                abilityGenerator.SpawnAbilities(abilities);
            }
        }

        public void GetDamage(float damage)
        {
            health.GetDamage(damage);
        }
    }
}
