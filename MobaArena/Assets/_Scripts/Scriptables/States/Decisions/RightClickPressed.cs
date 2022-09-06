using _Scripts.Units.Character;
using UnityEngine;

namespace _Scripts.Scriptables.States.Decisions
{
    [CreateAssetMenu(menuName = "Decisions/RightClickPressed")]
    public class RightClickPressed : CharacterDecision
    {
        private bool rightClickPressed = false;
        public override void SubscribeEvents(CharacterAttack characterAttack)
        {
            rightClickPressed = false;
            characterAttack.characterInput.rightClickAction += EventRightClickPressed;
        }

        public override bool Run(CharacterAttack characterAttack)
        {
            return rightClickPressed;
        }

        private void EventRightClickPressed()
        {
            Debug.Log("Right Click Pressed");
            rightClickPressed = true;
        }

        public override void UnSubscribeEvents(CharacterAttack characterAttack)
        {
            characterAttack.characterInput.rightClickAction -= EventRightClickPressed;
        }
    }
}