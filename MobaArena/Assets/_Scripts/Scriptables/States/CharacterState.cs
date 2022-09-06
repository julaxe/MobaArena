using System;
using System.Collections.Generic;
using _Scripts.Scriptables.States.Decisions;
using _Scripts.Units.Character;
using UnityEngine;

namespace _Scripts.Scriptables.States
{
    public abstract class CharacterState : ScriptableObject
    {
        [NonReorderable]
        public List<Transition> transitions;

        public virtual void OnEnter(CharacterAttack currentAttackState)
        {
            foreach (var transition in transitions)
            {
                transition.decision.SubscribeEvents(currentAttackState);
            }
        }

        public virtual void OnUpdate(CharacterAttack currentAttackState)
        {
            foreach (var transition in transitions)
            {
                if (transition.decision.Run(currentAttackState))
                {
                    currentAttackState.ChangeAttackState(transition.trueState);
                    return;
                }

                if (transition.falseState == null) continue;
                currentAttackState.ChangeAttackState(transition.falseState);
                return;
            }
        }

        public virtual void OnExit(CharacterAttack currentAttackState)
        {
            foreach (var transition in transitions)
            {
                transition.decision.UnSubscribeEvents(currentAttackState);
            }
        }
    }

    [Serializable]
    public struct Transition
    {
        public CharacterDecision decision;
        public CharacterState trueState;
        public CharacterState falseState;
    }
}