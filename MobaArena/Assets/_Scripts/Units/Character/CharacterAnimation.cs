using System;
using UnityEngine;

namespace _Scripts.Units.Character
{
    public class CharacterAnimation : MonoBehaviour
    {
        private CharacterMovement _characterMovement;
        public Animator animator;

        private readonly int _isWalkingHash = Animator.StringToHash("Walking");
        private void OnValidate()
        {
            _characterMovement = GetComponent<CharacterMovement>();
        }

        private void Update()
        {
            animator.SetBool(_isWalkingHash ,_characterMovement.isWalking);
        }
    }
}