using System;
using InteractableObjects.Core;
using TMPro;
using UnityEngine;

namespace InteractableObjects
{
    public class Experience : InteractableObject
    {
        [SerializeField] private int expValue;
        public static event Action<int> AddExp;
        private void Start()
        {
            Text.text += "+"+expValue + " exp ";
        }
        private void OnMouseDown()
        {
            if (IsInteractable()&& isDestroyable)
            {
                AddExp?.Invoke(expValue);
                Destroy(gameObject);
            }
        }
    }
}
