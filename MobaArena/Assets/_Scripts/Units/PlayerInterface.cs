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
        [SerializeField] private Image image;
        [SerializeField] private float cooldown;
        

        private VisualElement root;

        private void Start()
        {
            root = _uiDocument.rootVisualElement;
            root.Q<Button>("Q").clicked += SetAbilityOnCooldown;
        }

        private void SetAbilityOnCooldown()
        {
            StartCoroutine(CoolDownCoroutine(cooldown));
        }

        private void OnSpell1(InputValue value)
        {
            SetAbilityOnCooldown();
        }

        private IEnumerator CoolDownCoroutine(float cd)
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