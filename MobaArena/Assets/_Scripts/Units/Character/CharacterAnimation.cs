using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace _Scripts.Units.Character
{
    public class CharacterAnimation : MonoBehaviour
    {
        private CharacterMovement _characterMovement;
        private CharacterAttack _characterAttack;
        public Animator animator;

        private readonly int _isWalkingHash = Animator.StringToHash("Walking");
        private readonly int _basicAttack1Hash = Animator.StringToHash("BasicAttack1");
        private readonly int _basicAttack2Hash = Animator.StringToHash("BasicAttack2");

        public bool isWalking = false;
        private void OnValidate()
        {
            _characterMovement = GetComponent<CharacterMovement>();
            _characterAttack = GetComponent<CharacterAttack>();
        }

        private void Update()
        {
            animator.SetBool(_isWalkingHash ,isWalking);
        }

        public void TriggerBasicAttack()
        {
            animator.SetTrigger(Random.Range(0, 2) == 0 ? _basicAttack1Hash : _basicAttack2Hash);
        }
    }
}