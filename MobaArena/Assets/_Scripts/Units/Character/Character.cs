using System;
using _Scripts.Scriptables;
using UnityEngine;

namespace _Scripts.Units.Character
{
    public class Character : MonoBehaviour
    {
        public ScriptableCharacterBase baseCharacter;

        public CharacterState CharacterState { get; private set; }

        private void Awake()
        {
            CharacterState = CharacterState.Idle;
        }

        public void ChangeState(CharacterState state) => CharacterState = state;
    }

    public enum CharacterState
    {
        Idle,
        Moving,
        Attacking
    }
}