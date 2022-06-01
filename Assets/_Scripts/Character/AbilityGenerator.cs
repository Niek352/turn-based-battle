using System.Collections.Generic;
using _Scripts.Core;
using UnityEngine;

namespace _Scripts.Character
{
    public class AbilityGenerator : MonoBehaviour
    {
        [SerializeField] private AbilityItem prefabAbilityItem;
        [SerializeField] private Transform abilitiesRoot;
        private List<AbilityItem> abilityItems;
        private void ClearAbilities()
        {
            foreach (Transform ability in abilitiesRoot)
            {
                Destroy(ability.gameObject);
            }
        }
        public void SpawnAbilities(BaseAbility[] abilities)
        {
            ClearAbilities();
            foreach (var baseAbility in abilities)
            {
                var newAbility = Instantiate(prefabAbilityItem, abilitiesRoot,false);
                newAbility.Init(baseAbility);
            }
        }
    }
}