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

            currentAttackState.characterMovement.MoveToTarget();
            currentAttackState.characterAnimation.ToWalking();
        }

        public override void OnUpdate(CharacterAttack currentAttackState)
        {
            base.OnUpdate(currentAttackState);
            //rotate the character to that point
            var currentTransform = currentAttackState.transform;
            var view = currentAttackState.characterInput.CurrentTarget.position 
                       - currentTransform.position;
            currentAttackState.transform.rotation = Quaternion.Lerp(currentTransform.rotation, 
                Quaternion.LookRotation(view), 0.1f);
        }

        public override void OnExit(CharacterAttack currentAttackState)
        {
            base.OnExit(currentAttackState);
            
        }
    }
}