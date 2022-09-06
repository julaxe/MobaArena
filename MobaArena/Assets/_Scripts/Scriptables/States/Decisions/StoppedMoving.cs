using _Scripts.Units.Character;
using UnityEngine;

namespace _Scripts.Scriptables.States.Decisions
{
    [CreateAssetMenu(menuName = "Decisions/StoppedMoving")]
    public class StoppedMoving : CharacterDecision
    {
        public override void SubscribeEvents(CharacterAttack characterAttack)
        {
           
        }
        public override bool Run(CharacterAttack characterAttack)
        {
            return !characterAttack.characterMovement.NavMeshAgent.hasPath;
        }
        
        public override void UnSubscribeEvents(CharacterAttack characterAttack)
        {
            
        }
    }
}