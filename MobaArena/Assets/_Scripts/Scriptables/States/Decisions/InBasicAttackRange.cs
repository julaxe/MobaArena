using _Scripts.Units.Character;
using UnityEngine;

namespace _Scripts.Scriptables.States.Decisions
{
    [CreateAssetMenu(menuName = "Decisions/InBasicAttackRange")]
    public class InBasicAttackRange : CharacterDecision
    {
        public override void SubscribeEvents(CharacterAttack characterAttack)
        {
           
        }
        public override bool Run(CharacterAttack characterAttack)
        {
            return characterAttack.characterMovement.InsideRange(
                characterAttack.character.baseCharacter.BaseStats.otherStats.range);
        }
        
        public override void UnSubscribeEvents(CharacterAttack characterAttack)
        {
            
        }
    }
}