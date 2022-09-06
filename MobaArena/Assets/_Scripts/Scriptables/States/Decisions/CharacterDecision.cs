using _Scripts.Units.Character;
using UnityEngine;

namespace _Scripts.Scriptables.States.Decisions
{
    public abstract class CharacterDecision : ScriptableObject
    {
        public abstract void SubscribeEvents(CharacterAttack characterAttack); 
        public abstract bool Run(CharacterAttack characterAttack);
        
        public abstract void UnSubscribeEvents(CharacterAttack characterAttack); 
    }
}