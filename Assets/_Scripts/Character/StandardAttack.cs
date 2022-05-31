using UnityEngine;

namespace _Scripts.Character
{
    [CreateAssetMenu(fileName = "StandardAttack", menuName = "Abilities/StandardAttack")]
    public class StandardAttack : BaseAbility
    {
        [SerializeField] private float damage;
        
        protected override void UseAbility(BaseCharacter target)
        {
            
        }
    }
}