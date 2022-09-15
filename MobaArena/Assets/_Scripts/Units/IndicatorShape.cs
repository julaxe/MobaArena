using System;
using _Scripts.Units.Character;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Units
{
    public class IndicatorShape : MonoBehaviour
    {
        public CharacterInput CharacterInput;
        [SerializeField] private RectTransform indicatorImage;

        [SerializeField] private float maxDistance;

        private void Update()
        {
            var distance = Vector3.Distance(CharacterInput.CurrentMousePos, transform.position);
            if (distance >= maxDistance) distance = maxDistance;
            
            indicatorImage.localScale = new Vector3(1.0f, distance, 1.0f);
            indicatorImage.localPosition = new Vector3(0.0f, 0.1f, distance * 0.5f);
            
            var direction = (CharacterInput.CurrentMousePos - transform.position).normalized;
            var angle = Vector3.SignedAngle( Vector3.forward, direction, Vector3.up);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
            //indicatorImage.rotation = Quaternion.Euler(90, 0.0f, angle);

        }
    }
}