using _Scripts.Units.Character;
using UnityEngine;

namespace _Scripts.Scriptables.States.Decisions
{
    [CreateAssetMenu(menuName = "Decisions/RightClickPressed")]
    public class RightClickPressed : CharacterDecision
    {
        public override void SubscribeEvents(CharacterAttack characterAttack)
        {
        }

        public override bool Run(CharacterAttack characterAttack)
        {
            return characterAttack.characterInput.rightClickPressed;
        }
        

        public override void UnSubscribeEvents(CharacterAttack characterAttack)
        {
        }
    }
}