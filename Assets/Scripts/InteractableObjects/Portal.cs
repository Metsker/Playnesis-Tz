using System;
using InteractableObjects.Core;
using UnityEngine.SceneManagement;

namespace InteractableObjects
{
    public class Portal : InteractableObject
    {
        public static bool LoadLevel;
        public static event Action BuildPortals;
        public static event Action Teleport;

        private void OnMouseDown()
        {
            if (IsInteractable() && isDestroyable)
            {
                if (!LoadLevel)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1, LoadSceneMode.Additive);
                    LoadLevel = true;
                    Invoke(nameof(TeleportPLayer), 0.5f);
                }
                else
                {
                    Teleport?.Invoke();
                }
            }
        }

        private void TeleportPLayer()
        {
            BuildPortals?.Invoke();
            Teleport?.Invoke();
        }
    }
}
