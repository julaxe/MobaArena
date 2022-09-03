using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Units.Character
{
    public class CharacterInput : MonoBehaviour
    {
        public Vector3 CurrentMousePos { get; private set; }
        public Transform CurrentTarget { get; private set; }
        public CommandType CommandType { get; private set; }
        [SerializeField] private LayerMask interactionLayer;
        [Header("Cursor")]
        [SerializeField] private Texture2D defaultCursorTexture;
        [SerializeField] private Texture2D attackCursorTexture;
        private void Update()
        {
            var mousePos = Mouse.current.position;

            var movePosition = Camera.main.ScreenPointToRay(mousePos.ReadValue());

            if (Physics.Raycast(movePosition, out var hitInfo, Mathf.Infinity, interactionLayer.value ))
            {
                CurrentMousePos = hitInfo.point;
                if (hitInfo.transform.CompareTag("Enemy"))
                {
                    SetAttackCursor();
                    SetTarget(hitInfo.transform);
                }
                else
                {
                    SetDefaultCursor();
                }
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
    }

    public enum CommandType
    {
        Move,
        Attack
    }
}