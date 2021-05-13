using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class Restart : MonoBehaviour
    {
        public void RestartGame()
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
