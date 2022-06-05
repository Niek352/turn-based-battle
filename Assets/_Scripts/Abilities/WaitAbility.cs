using System;
using _Scripts.Character;
using UnityEngine;

namespace _Scripts.Abilities
{
    [CreateAssetMenu(fileName = "WaitAbility", menuName = "Abilities/WaitAbility")]
    public class WaitAbility : BaseAbility
    {
        protected override void UseAbility()
        {
            Debug.Log("Wait");
        }

        
    }
}