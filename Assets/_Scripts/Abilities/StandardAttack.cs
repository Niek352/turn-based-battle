using System;
using _Scripts.Character;
using UnityEngine;

namespace _Scripts.Abilities
{
    [CreateAssetMenu(fileName = "StandardAttack", menuName = "Abilities/StandardAttack")]
    public class StandardAttack : TargetAbility
    {
        [SerializeField] private float damage;
        
        protected override void UseAbilityOnTarget(BaseCharacter baseCharacter)
        {
            baseCharacter.GetDamage(damage);
        }
    }
}