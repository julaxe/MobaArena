using _Scripts.Units.Character;
using UnityEngine;

namespace _Scripts.Scriptables.States
{
    [CreateAssetMenu(menuName = "States/BasicAttackState")]
    public class BasicAttackState : CharacterState
    {
        public override void OnEnter(CharacterAttack currentAttackState)
        {
            base.OnEnter(currentAttackState);

            currentAttackState.characterMovement.StopMovement();
            
            currentAttackState.characterAnimation.TriggerBasicAttack();
        }

        public override void OnUpdate(CharacterAttack currentAttackState)
        {
            base.OnUpdate(currentAttackState);
            
        }

        public override void OnExit(CharacterAttack currentAttackState)
        {
            base.OnExit(currentAttackState);
            
        }
    }
}