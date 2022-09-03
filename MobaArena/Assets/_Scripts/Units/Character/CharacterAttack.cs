using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _Scripts.Units.Character
{
    public class CharacterAttack : MonoBehaviour
    {
        private Character _character;
        private CharacterInput _characterInput;
        private CharacterMovement _characterMovement;
        private Transform _target;
        public bool IsAttacking { get; private set; }
        public UnityAction attackEvent;


        private void OnValidate()
        {
            _character = GetComponent<Character>();
            _characterInput = GetComponent<CharacterInput>();
            _characterMovement = GetComponent<CharacterMovement>();
        }

        private void Update()
        {
            if (_character.CharacterState != CharacterState.Attacking) return;

            if (IsAttacking) return;
            
            if (_characterMovement.InsideRange(_character.baseCharacter.BaseStats.otherStats.range))
            {
                _characterMovement.StopMovement();
                
                //attack
                BasicAttack();
            }
            
        }

        private void BasicAttack()
        {
            IsAttacking = true;
            attackEvent?.Invoke();
        }
        
        private void OnRightClick(InputValue value)
        {
            if (_characterInput.CommandType != CommandType.Attack) return;

            IsAttacking = false;
            _character.ChangeState(CharacterState.Attacking);
            _target = _characterInput.CurrentTarget;
            _characterMovement.MoveToPoint(_target.position);
        }
    }
}