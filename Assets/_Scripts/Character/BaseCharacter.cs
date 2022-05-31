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
        [SerializeField] private BaseAbility[] abilities;

        public bool IsEnemy { get; private set; }

        public void Init(bool isEnemy)
        {
            this.IsEnemy = isEnemy;
            skeletonAnimation.initialFlipX = isEnemy;
            skeletonAnimation.Initialize(true);
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
                                
                
                
            }
        }
    }
}
