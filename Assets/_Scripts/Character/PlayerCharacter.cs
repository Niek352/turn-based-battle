using _Scripts.Abilities;

namespace _Scripts.Character
{
    public class PlayerCharacter : BaseCharacter
    {
        private AbilityGenerator abilityGenerator;

        public static bool CanUseAbility = false;

        public override void Init(bool isEnemy, CharacterData data)
        {
            base.Init(isEnemy, data);
            abilityGenerator = AbilityGenerator.Instance;
        }

        private void OnMouseDown()
        {
            if (CanUseAbility && IsAlive)
            {
                abilityGenerator.SpawnAbilities(this,data.Abilities);
            }
        }
    }
}