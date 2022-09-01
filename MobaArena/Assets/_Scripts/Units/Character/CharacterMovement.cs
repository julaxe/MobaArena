using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace _Scripts.Units.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;

        public bool isWalking;
        
        private void OnValidate()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void OnRightClick(InputValue value)
        {
            //move to the position

            var mousePos = Mouse.current.position;

            Ray movePosition = Camera.main.ScreenPointToRay(mousePos.ReadValue());

            if (Physics.Raycast(movePosition, out var hitInfo))
            {
                _navMeshAgent.SetDestination(hitInfo.point);
            }
        }

        private void Update()
        {
            isWalking = _navMeshAgent.hasPath;
        }
    }
}