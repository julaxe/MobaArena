using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace _Scripts.Units.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        private CharacterInput _characterInput;

        public bool isWalking;
        
        private void OnValidate()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _characterInput = GetComponent<CharacterInput>();
        }

        private void OnRightClick(InputValue value)
        {
            //move to the position
            _navMeshAgent.SetDestination(_characterInput.GetCurrentMousePosition());
            
        }

        private void Update()
        {
            isWalking = _navMeshAgent.hasPath;
        }
    }
}