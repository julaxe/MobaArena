using _Scripts.Units.Character;
using UnityEngine;

namespace _Scripts.Scriptables.States
{
    [CreateAssetMenu(menuName = "States/MovingState")]
    public class MovingState : CharacterState
    {
        public override void OnEnter(CharacterAttack currentAttackState)
        {
            base.OnEnter(currentAttackState);

            currentAttackState.characterMovement.MoveToMousePosition();
            currentAttackState.characterAnimation.ToWalking();
        }

        public override void OnUpdate(CharacterAttack currentAttackState)
        {
            base.OnUpdate(currentAttackState);
            //rotate the character to that point
            var currentTransform = currentAttackState.transform;
            var view = currentAttackState.characterInput.CurrentMouseDestination 
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