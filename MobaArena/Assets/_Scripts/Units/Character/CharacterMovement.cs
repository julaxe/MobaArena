using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace _Scripts.Units.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        private Character _character;
        private CharacterInput _characterInput;
        private NavMeshAgent _navMeshAgent;
        

        public bool isWalking;
        
        private void OnValidate()
        {
            _character = GetComponent<Character>();
            _characterInput = GetComponent<CharacterInput>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
        
        private void Update()
        {
            isWalking = _navMeshAgent.hasPath;
            
            if (_character.CharacterState != CharacterState.Moving) return;
            
            if(!isWalking) _character.ChangeState(CharacterState.Idle);
        }
        
        private void OnRightClick(InputValue value)
        {
            //move to the position
            if (_characterInput.CommandType == CommandType.Move)
            {
                MoveToPoint(_characterInput.CurrentMousePos);
                _character.ChangeState(CharacterState.Moving);
            }

        }

        public void MoveToPoint(Vector3 point)
        {
            _navMeshAgent.SetDestination(point);
        }

        public bool InsideRange(float distance)
        {
            return _navMeshAgent.remainingDistance <= distance*0.01;
        }

        public void StopMovement()
        {
            _navMeshAgent.SetDestination(transform.position);
        }

        
    }
}