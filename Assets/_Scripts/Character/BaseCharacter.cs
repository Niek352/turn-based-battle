using System;
using Spine.Unity;
using UnityEngine;

namespace _Scripts.Character
{
    [RequireComponent(typeof(Health))]
    public class BaseCharacter : MonoBehaviour
    {
        [SerializeField] private Health health;
        [SerializeField] private SkeletonAnimation skeletonAnimation;
        [SerializeField] private CharacterHover characterHover;
        [SerializeField] private BaseAbility[] abilities;
        private AbilityGenerator abilityGenerator;

        public CharacterHover CharacterHover => characterHover;
        public bool IsEnemy { get; private set; }

        public void Init(bool isEnemy, AbilityGenerator abilityGenerator)
        {
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
    }
}
