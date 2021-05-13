using Character;
using UnityEngine;

namespace CameraLogic
{
    public class CameraControl : MonoBehaviour
    {
        private GameObject _player;

        private void Start()
        {
            _player = FindObjectOfType<CharacterStats>().gameObject;
        }

        private void LateUpdate()
        {
            var playerPos = _player.transform.position;
            var cameraPos = transform.position;
            transform.position = new Vector3(playerPos.x, cameraPos.y, playerPos.z);
        }
    }
}
