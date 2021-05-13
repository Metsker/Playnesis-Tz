using UnityEngine;
using UnityEngine.AI;

namespace Character
{
    public class CharacterControls : MonoBehaviour
    {
        private Camera _camera;
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _camera = Camera.main;
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && !GameManager.GameOver)
            {
                Controls();
            }
        }

        private void Controls()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _navMeshAgent.SetDestination(hit.point);
            }
        }
    }
}
