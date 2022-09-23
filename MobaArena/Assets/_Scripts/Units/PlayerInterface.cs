using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

namespace _Scripts.Units
{
    public class PlayerInterface : MonoBehaviour
    {
        [SerializeField] private UIDocument _uiDocument;
        [SerializeField] private Image imageSpell1;
        [SerializeField] private Image imageSpell2;
        [SerializeField] private Image imageSpell3;
        [SerializeField] private Image imageSpell4;
        [SerializeField] private float cooldown;

        public bool IsSpell1Available() => !imageSpell1.enabled;
        public bool IsSpell2Available() => !imageSpell2.enabled;
        public bool IsSpell3Available() => !imageSpell3.enabled;
        public bool IsSpell4Available() => !imageSpell4.enabled;
        
        

        private VisualElement root;

        private void Start()
        {
            root = _uiDocument.rootVisualElement;
            root.Q<Button>("Q").clicked += () => SetAbilityOnCooldown(imageSpell1);
            root.Q<Button>("W").clicked += () => SetAbilityOnCooldown(imageSpell2);
            root.Q<Button>("E").clicked += () => SetAbilityOnCooldown(imageSpell3);
            root.Q<Button>("R").clicked += () => SetAbilityOnCooldown(imageSpell4);
        }

        private void SetAbilityOnCooldown(Image imageSpell)
        {
            StartCoroutine(CoolDownCoroutine(cooldown, imageSpell));
        }

        private void OnSpell1(InputValue value)
        {
            SetAbilityOnCooldown(imageSpell1);
        }
        private void OnSpell2(InputValue value)
        {
            SetAbilityOnCooldown(imageSpell2);
        }
        private void OnSpell3(InputValue value)
        {
            SetAbilityOnCooldown(imageSpell3);
        }
        private void OnSpell4(InputValue value)
        {
            SetAbilityOnCooldown(imageSpell4);
        }

        private IEnumerator CoolDownCoroutine(float cd, Image image)
        {
            if (image.enabled) yield break;
            float startTime = Time.time;
            float endTime = Time.time + cd;

            image.enabled = true;
            while (Time.time < endTime)
            {
                image.fillAmount = Mathf.Lerp(1, 0, (Time.time - startTime)/ cd);
                yield return null;
            }
            image.enabled = false;
        }
    }
}