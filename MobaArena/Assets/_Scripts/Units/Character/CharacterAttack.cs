using System;
using _Scripts.Scriptables.States;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace _Scripts.Units.Character
{
    public class CharacterAttack : MonoBehaviour
    {
        [NonSerialized] public Character character;
        [NonSerialized] public CharacterInput characterInput;
        [NonSerialized] public CharacterMovement characterMovement;
        [NonSerialized] public CharacterAnimation characterAnimation;

        public CharacterState currentState;


        private void OnValidate()
        {
            character = GetComponent<Character>();
            characterInput = GetComponent<CharacterInput>();
            characterMovement = GetComponent<CharacterMovement>();
            characterAnimation = GetComponent<CharacterAnimation>();
        }

        private void Start()
        {
            if (currentState != null)
                currentState.OnEnter(this);
        }

        private void Update()
        {
            currentState.OnUpdate(this);
        }

        public void ChangeAttackState(CharacterState state)
        {
            currentState.OnExit(this);
            currentState = state;
            currentState.OnEnter(this);
        }
        
    }
}