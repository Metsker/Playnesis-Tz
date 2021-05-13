using System;
using InteractableObjects.Core;
using UnityEngine;

namespace InteractableObjects
{
    public class TextView : InteractableObject
    {
        [SerializeField] private string description;
        [SerializeField] private float startViewTime = 7;
        public static float ViewTime;
        public static event Action<string> StartDescriptionTimer;
        
        private void OnMouseDown()
        {
            if (IsInteractable() && isDestroyable)
            {
                ViewTime = startViewTime;
                StartDescriptionTimer?.Invoke(description);
                Destroy(gameObject);  
            }
        }
    }
}
