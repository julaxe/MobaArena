using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace _Scripts.Units.Character
{
    public class CharacterAnimation : MonoBehaviour
    {
        public Animator animator;

        private static readonly int Walking = Animator.StringToHash("Walking");
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int IdleIn = Animator.StringToHash("IdleIn");
        private static readonly int Attack1 = Animator.StringToHash("Attack 1");
        private static readonly int Attack2 = Animator.StringToHash("Attack 2");

        public void ToIdle()
        {
            animator.CrossFade(Idle, 0.2f, 0);
        }
        
        public void ToWalking()
        {
            animator.CrossFade(Walking, 0.00f, 0);
        }

        public void TriggerBasicAttack()
        {
            animator.CrossFade(Random.Range(0, 2) == 0 ? Attack1 : Attack2, 0.0f, 0);
        }

        public void PlayAnimation(string animationName, float transitionTime = 0.0f)
        {
            animator.CrossFade(animationName, transitionTime, 0);
        }
    }
}