using System;
using Spine.Unity;
using UnityEngine;

namespace _Scripts.Character
{
    [RequireComponent(typeof(Health))]
    public class BaseCharacter : MonoBehaviour
    {
        private Health health;
        private SkeletonAnimation skeletonAnimation;

        public void Init()
        {
            
        }
        
        private void OnValidate()
        {
            health = GetComponent<Health>();
            skeletonAnimation = GetComponentInChildren<SkeletonAnimation>();
        }
    }
}
