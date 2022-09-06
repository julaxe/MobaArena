using _Scripts.Units.Character;
using UnityEngine;

namespace _Scripts.Scriptables.States
{
    [CreateAssetMenu(menuName = "States/MoveAttackState")]
    public class MoveAttackState : CharacterState
    {
        public override void OnEnter(CharacterAttack currentAttackState)
        {
            base.OnEnter(currentAttackState);
            
            Debug.Log("Enter MoveAttackState state");
            currentAttackState.characterMovement.MoveToTarget();
        }

        public override void OnUpdate(CharacterAttack currentAttackState)
        {
            base.OnUpdate(currentAttackState);

            currentAttackState.characterAnimation.isWalking = 
                currentAttackState.characterMovement.NavMeshAgent.hasPath;
        }

        public override void OnExit(CharacterAttack currentAttackState)
        {
            base.OnExit(currentAttackState);
            
        }
    }
}