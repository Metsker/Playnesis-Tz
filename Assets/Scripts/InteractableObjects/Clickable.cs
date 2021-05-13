using InteractableObjects.Core;
using TMPro;
using UnityEngine;

namespace InteractableObjects
{
    public class Clickable : InteractableObject
    {
        [SerializeField] private int requiredClicks;
        private string _cash;
        private int _doneClicks;

        private void Start()
        {
            foreach (var t in GetComponents<InteractableObject>())
            {
                t.isDestroyable = false;
            }
            _cash = Text.text;
            Text.text += requiredClicks + " tap ";
        }

        private void OnMouseDown()
        {
            if (!IsInteractable()) return;
            
            _doneClicks++;
            Text.text = _cash + (requiredClicks - _doneClicks) + " tap ";

            if (_doneClicks == requiredClicks-1)
            {
                foreach (var t in GetComponents<InteractableObject>())
                {
                    t.isDestroyable = true;
                }
            }
            else if (_doneClicks == requiredClicks)
            {
                Invoke(nameof(DelayedDestroy), 0.05f);
            }
        }

        private void DelayedDestroy()
        {
            Destroy(gameObject);
        }
    }
}
