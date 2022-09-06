using System;
using _Scripts.Scriptables.States;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _Scripts.Units.Character
{
    public class CharacterAttack : MonoBehaviour
    {
        [NonSerialized] public Character character;
        [NonSerialized] public CharacterInput characterInput;
        [NonSerialized] public CharacterMovement characterMovement;
        [NonSerialized] public CharacterAnimation characterAnimation;
        [NonSerialized] public Transform target;
        
        public bool IsAttacking { get; private set; }
        public UnityAction AttackEvent;
        public CharacterState currentState;


        private void OnValidate()
        {
            character = GetComponent<Character>();
            characterInput = GetComponent<CharacterInput>();
            characterMovement = GetComponent<CharacterMovement>();
        }

        private void Start()
        {
            if (currentState != null)
                currentState.OnEnter(this);
        }

        private void Update()
        {
            currentState.OnUpdate(this);
            
            
            if (characterMovement.InsideRange(character.baseCharacter.BaseStats.otherStats.range))
            {
                characterMovement.StopMovement();
                
                //attack
                BasicAttack();
            }
            
        }

        public void ChangeAttackState(CharacterState state)
        {
            if (currentState == state) return;
            currentState.OnExit(this);
            currentState = state;
            currentState.OnEnter(this);
        }

        private void BasicAttack()
        {
            IsAttacking = true;
            AttackEvent?.Invoke();
        }
        
        private void OnRightClick(InputValue value)
        {
            if (characterInput.CommandType != CommandType.Attack) return;

            IsAttacking = false;
            target = characterInput.CurrentTarget;
            characterMovement.MoveToPoint(target.position);
        }
    }
}