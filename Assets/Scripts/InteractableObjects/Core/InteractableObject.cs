using TMPro;
using UnityEngine;

namespace InteractableObjects.Core
{
    public class InteractableObject : MonoBehaviour
    {
        private InteractableArea _interactableArea;
        protected TextMeshProUGUI Text;
        
        [HideInInspector]
        public bool isDestroyable = true;
        
        protected void Awake()
        {
            _interactableArea = GetComponentInChildren<InteractableArea>();
            Text = GetComponentInChildren<TextMeshProUGUI>();
        }

        protected void OnEnable()
        {
            _interactableArea.UpdateStatement += IsInteractable;
        }
        
        
        protected void OnDisable()
        {
            _interactableArea.UpdateStatement -= IsInteractable;
        }

        protected bool IsInteractable()
        {
            return _interactableArea.interactable;
        }
    }
}
