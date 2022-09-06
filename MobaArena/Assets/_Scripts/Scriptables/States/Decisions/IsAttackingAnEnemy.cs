using _Scripts.Units.Character;
using UnityEngine;

namespace _Scripts.Scriptables.States.Decisions
{
    [CreateAssetMenu(menuName = "Decisions/IsAttackingAnEnemy")]
    public class IsAttackingAnEnemy : CharacterDecision
    {
        public override void SubscribeEvents(CharacterAttack characterAttack)
        {
           
        }
        public override bool Run(CharacterAttack characterAttack)
        {
            return characterAttack.characterInput.IsTargetAnEnemy;
        }
        
        public override void UnSubscribeEvents(CharacterAttack characterAttack)
        {
            
        }
    }
}