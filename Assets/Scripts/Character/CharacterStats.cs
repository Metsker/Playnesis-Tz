using System;
using InteractableObjects;
using UnityEngine;

namespace Character
{
    public class CharacterStats : CharacterControls
    {
        public int health;
        public int exp;
        public static event Action<int> UpdateHpUI;
        public static event Action<int> UpdateExpUI;
        public static event Action GameOver;
        
        private void Start()
        {
            UpdateHpUI?.Invoke(health);
        }
        
        private void OnEnable()
        {
            Experience.AddExp += AddExp;
            Health.RemoveHealth += RemoveHealth;
        }

        private void OnDisable()
        {
            Experience.AddExp -= AddExp;
            Health.RemoveHealth -= RemoveHealth;
        }
        
        private void RemoveHealth(int value)
        {
            health -= value;
            UpdateHpUI?.Invoke(health);
            if (health > 0) return;
            GameOver?.Invoke();
        }
        
        private void AddExp(int value)
        {
            exp += value;
            UpdateExpUI?.Invoke(exp);
        }
    }
}
