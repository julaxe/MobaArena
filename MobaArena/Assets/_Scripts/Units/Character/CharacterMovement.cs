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
        [NonSerialized] public NavMeshAgent NavMeshAgent;

        private void Awake()
        {
            _character = GetComponent<Character>();
            _characterInput = GetComponent<CharacterInput>();
            NavMeshAgent = GetComponent<NavMeshAgent>();
            NavMeshAgent.updateRotation = false;
        }


        public void MoveToMousePosition()
        {
            MoveToPoint(_characterInput.CurrentMousePos);
        }

        public void MoveToTarget()
        {
            MoveToPoint(_characterInput.CurrentTarget.position);
        }
        private void MoveToPoint(Vector3 point)
        {
            NavMeshAgent.SetDestination(point);
        }

        public bool InsideRange(float range)
        {
            var distance = Vector3.Distance(transform.position, _characterInput.CurrentTarget.position);
            return distance <= range*0.01;
        }

        public void StopMovement()
        {
            NavMeshAgent.SetDestination(transform.position);
        }

        
    }
}