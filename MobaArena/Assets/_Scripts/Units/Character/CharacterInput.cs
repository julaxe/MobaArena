using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace _Scripts.Units.Character
{
    public class CharacterInput : MonoBehaviour
    {
        public Vector3 CurrentMousePos { get; private set; }
        
        //this is for attacking
        public Transform CurrentTarget { get; private set; }
        
        //this is when clicking with mouse on terrain (not enemy)
        public Vector3 CurrentMouseDestination { get; private set; }
        
        public bool IsTargetAnEnemy { get; private set; }
        public CommandType CommandType { get; private set; }
        
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private LayerMask groundLayer;
        
        [Header("Cursor")]
        [SerializeField] private Texture2D defaultCursorTexture;
        [SerializeField] private Texture2D attackCursorTexture;

        [NonSerialized] public bool rightClickPressed;
        [NonSerialized] public bool QPressed;

        private void Update()
        {
            var mousePos = Mouse.current.position;

            var movePosition = Camera.main.ScreenPointToRay(mousePos.ReadValue());

            if (Physics.Raycast(movePosition, out var hitInfoEnemy, Mathf.Infinity, targetLayer.value ))
            {
                    SetAttackCursor();
                    IsTargetAnEnemy = true;
                    SetTarget(hitInfoEnemy.transform);
            }
            else
            {
                SetDefaultCursor();
                IsTargetAnEnemy = false;
            }
            
            if(Physics.Raycast(movePosition, out var hitInfo, Mathf.Infinity, groundLayer.value))
            {
                CurrentMousePos = hitInfo.point;
            }
        }

        private void SetDefaultCursor()
        {
            CommandType = CommandType.Move;
            Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto);
        }
        
        private void SetAttackCursor()
        {
            CommandType = CommandType.Attack;
            Cursor.SetCursor(attackCursorTexture, Vector2.zero, CursorMode.Auto);
        }

        private void SetTarget(Transform target) => CurrentTarget = target;

        private void OnRightClick(InputValue value)
        {
            rightClickPressed = value.isPressed;
            if (rightClickPressed)
            {
                CurrentMouseDestination = CurrentMousePos;
            }
        }

        private void OnSpell1(InputValue value)
        {
            QPressed = value.isPressed;
        }
    }

    public enum CommandType
    {
        Move,
        Attack
    }
}