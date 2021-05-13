using UnityEngine;

namespace InteractableObjects.Core
{
    [CreateAssetMenu(fileName = "New SpawnPositions", menuName = "SpawnPositions")]
    public class SpawnPositions : ScriptableObject
    {
        public Vector3[] positions;
    }
}
