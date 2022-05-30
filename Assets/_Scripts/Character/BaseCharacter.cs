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
        private bool isEnemy;
        
        public void Init(bool isEnemy)
        {
            this.isEnemy = isEnemy;
            skeletonAnimation.initialFlipX = isEnemy;
            skeletonAnimation.Initialize(true);


        }
        
        private void OnValidate()
        {
            health = GetComponent<Health>();
            skeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
        }
    }
}
