using System;
using _Scripts.Abilities;
using Spine.Unity;
using UnityEngine;

namespace _Scripts.Character
{
    [RequireComponent(typeof(Health))]
    public class BaseCharacter : MonoBehaviour
    {
        [Header("Links")]
        [SerializeField] private Health health;
        [SerializeField] private SkeletonAnimation skeletonAnimation;
        [SerializeField] private CharacterHover characterHover;
        [SerializeField] private CharacterAnimation characterAnimation;
        [SerializeField] private Vector3 initPosition;

        protected CharacterData data;
        
        
        public Vector3 InitPosition => initPosition;
        public CharacterAnimation CharacterAnimation => characterAnimation;
        public CharacterHover CharacterHover => characterHover;
        public bool IsAlive => health.IsAlive;
        public bool IsEnemy { get; private set; }

        public virtual void Init(bool isEnemy, CharacterData data)
        {
            this.data = data;
            health.Init(this, data.MaxHealth);
            this.IsEnemy = isEnemy;
            skeletonAnimation.initialFlipX = isEnemy;
            skeletonAnimation.Initialize(true);
            initPosition = transform.position;
        }
        
        private void OnValidate()
        {
            health = GetComponent<Health>();
            skeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
        }

        public void GetDamage(float damage)
        {
            health.GetDamage(damage);
            characterAnimation.TriggerAnimation("Damage",(() => print("End")));
        }
    }
}
