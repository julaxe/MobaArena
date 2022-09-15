using _Scripts.Units.Character;
using UnityEngine;

namespace _Scripts.Scriptables.States.Decisions
{
    [CreateAssetMenu(menuName = "Decisions/QPressed")]
    public class QPressed : CharacterDecision
    {
        public override void SubscribeEvents(CharacterAttack characterAttack)
        {
            
        }

        public override bool Run(CharacterAttack characterAttack)
        {
            return characterAttack.characterInput.QPressed;
        }

        public override void UnSubscribeEvents(CharacterAttack characterAttack)
        {
        }
    }
}