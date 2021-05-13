using System;
using InteractableObjects.Core;
using TMPro;
using UnityEngine;

namespace InteractableObjects
{
    public class Health : InteractableObject
    {
        [SerializeField] private int hpValue;
        public static event Action<int> RemoveHealth;

        private new void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            Text.text += "-"+hpValue + " hp  ";
        }
        private void OnMouseDown()
        {
            if (IsInteractable() && isDestroyable)
            {
                RemoveHealth?.Invoke(hpValue);
                Destroy(gameObject); 
            }
        }
    }
}
