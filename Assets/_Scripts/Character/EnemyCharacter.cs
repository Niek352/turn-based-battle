using UnityEngine;

namespace _Scripts.Character
{
    public class EnemyCharacter : BaseCharacter
    {
        public void DoAction()
        {
            var ability = data.Abilities[Random.Range(0, data.Abilities.Length)];
            ability.OnClick(this);
        }
    }
}