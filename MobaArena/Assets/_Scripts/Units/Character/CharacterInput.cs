using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts.Units.Character
{
    public class CharacterInput : MonoBehaviour
    {
        private Vector3 _currentMousePos;
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
                _currentMousePos = hitInfo.point;
                if (hitInfo.transform.CompareTag("Enemy"))
                {
                    SetAttackCursorTexture();
                }
                else
                {
                    SetDefaultCursorTexture();
                }
            }
        }

        private void SetDefaultCursorTexture()
        {
            Cursor.SetCursor(defaultCursorTexture, Vector2.zero, CursorMode.Auto);
        }
        
        private void SetAttackCursorTexture()
        {
            Cursor.SetCursor(attackCursorTexture, Vector2.zero, CursorMode.Auto);
        }

        public Vector3 GetCurrentMousePosition() => _currentMousePos;

    }
}