using System;
using System.Collections.Generic;
using _Scripts.Character;
using _Scripts.Utilities;
using UnityEngine;

namespace _Scripts.Abilities
{
    public class AbilityGenerator : Singleton<AbilityGenerator>
    {
        [SerializeField] private AbilityItem prefabAbilityItem;
        [SerializeField] private Transform abilitiesRoot;
        private List<AbilityItem> abilityItems;

        private void Awake()
        {
            BaseAbility.onAbilityUsed += OnAbilityUsed;
        }

        private void OnDisable()
        {
            BaseAbility.onAbilityUsed -= OnAbilityUsed;
        }

        private void OnAbilityUsed()
        {
            ClearAbilities();
        }

        private void ClearAbilities()
        {
            foreach (Transform ability in abilitiesRoot)
            {
                Destroy(ability.gameObject);
            }
        }
        public void SpawnAbilities(BaseCharacter character, BaseAbility[] abilities)
        {
            ClearAbilities();
            foreach (var baseAbility in abilities)
            {
                var newAbility = Instantiate(prefabAbilityItem, abilitiesRoot,false);
                newAbility.Init(character,baseAbility);
            }
        }
    }
}