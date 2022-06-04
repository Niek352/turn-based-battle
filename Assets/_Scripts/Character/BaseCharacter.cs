using System;
using _Scripts.Abilities;
using Spine.Unity;
using UnityEngine;

namespace _Scripts.Character
{
    [RequireComponent(typeof(Health))]
    public class BaseCharacter : MonoBehaviour
    {

        private CharacterData data;
        [Header("Links")]
        [SerializeField] private Health health;
        [SerializeField] private SkeletonAnimation skeletonAnimation;
        [SerializeField] private CharacterHover characterHover;
        [SerializeField] private CharacterAnimation characterAnimation;
        
        private AbilityGenerator abilityGenerator;


        public CharacterAnimation CharacterAnimation => characterAnimation;
        public CharacterHover CharacterHover => characterHover;
        
        public bool IsEnemy { get; private set; }

        public void Init(bool isEnemy, AbilityGenerator abilityGenerator, CharacterData data)
        {
            this.data = data;
            health.Init(data.MaxHealth);
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
                abilityGenerator.SpawnAbilities(this,data.Abilities);
            }
        }

        public void GetDamage(float damage)
        {
            health.GetDamage(damage);
            characterAnimation.TriggerAnimation("Damage",(() => print("End")));
        }
    }
}
