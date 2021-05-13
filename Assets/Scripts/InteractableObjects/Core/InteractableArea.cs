using System;
using Character;
using UnityEngine;

namespace InteractableObjects.Core
{
    public class InteractableArea : MonoBehaviour
    {
        [SerializeField] private GameObject indicator;
        public event Func<bool> UpdateStatement;
        
        [HideInInspector]
        public bool interactable;

        private void Awake()
        {
            Physics.queriesHitTriggers = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CharacterControls _))
            {
                interactable = true;
                UpdateStatement?.Invoke();
                indicator.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out CharacterControls _))
            {
                interactable = false;
                UpdateStatement?.Invoke();
                indicator.SetActive(false);
            }
        }
    }
}
