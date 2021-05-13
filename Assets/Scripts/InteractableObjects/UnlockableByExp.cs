using System;
using Character;
using InteractableObjects.Core;
using TMPro;
using UnityEngine;

namespace InteractableObjects
{
    public class UnlockableByExp : InteractableObject
    {
        [SerializeField] private int expRequire;
        private string _cash;
        private CharacterStats _characterStats;

        private new void OnEnable()
        {
            base.OnEnable();
            CharacterStats.UpdateExpUI += UpdateUI;
        }

        private new void OnDisable()
        {
            base.OnDisable();
            CharacterStats.UpdateExpUI -= UpdateUI;
        }

        private void Start()
        {
            _characterStats = FindObjectOfType<CharacterStats>();
            
            foreach (var t in GetComponents<InteractableObject>())
            {
                t.isDestroyable = false;
            }
            
            _cash = Text.text;
            Text.text = _cash + expRequire + " exp left   ";
            
        }
        private void OnMouseDown()
        {
            if (IsInteractable()&&_characterStats.exp >= expRequire)
            {
                Invoke(nameof(DelayedDestroy), 0.05f);
            }
        }
        private void DelayedDestroy()
        {
            Destroy(gameObject);
        }
        private void UpdateUI(int exp)
        {
            var diff = expRequire - exp;
            
            if (diff <= 0)
            {
                foreach (var t in GetComponents<InteractableObject>())
                {
                    t.isDestroyable = true;
                }
                diff = 0;
            }
            Text.text = _cash + diff + " exp left   ";
        }
    }
}
