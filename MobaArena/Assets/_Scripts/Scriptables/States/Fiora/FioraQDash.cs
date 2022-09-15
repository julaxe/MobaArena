using _Scripts.Units.Character;
using UnityEngine;

namespace _Scripts.Scriptables.States
{
    [CreateAssetMenu(menuName = "States/Fiora/QDash")]
    public class FioraQDash : CharacterState
    {
        public override void OnEnter(CharacterAttack currentAttackState)
        {
            base.OnEnter(currentAttackState);

            currentAttackState.characterAnimation.PlayAnimation("Q Dash");
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