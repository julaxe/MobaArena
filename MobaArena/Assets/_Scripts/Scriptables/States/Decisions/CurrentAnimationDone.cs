using _Scripts.Units.Character;
using UnityEngine;

namespace _Scripts.Scriptables.States.Decisions
{
    [CreateAssetMenu(menuName = "Decisions/CurrentAnimationDone")]
    public class CurrentAnimationDone : CharacterDecision
    {
        public override void SubscribeEvents(CharacterAttack characterAttack)
        {
           
        }
        public override bool Run(CharacterAttack characterAttack)
        {
            return characterAttack.characterAnimation.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f;
        }
        
        public override void UnSubscribeEvents(CharacterAttack characterAttack)
        {
            
        }
    }
}