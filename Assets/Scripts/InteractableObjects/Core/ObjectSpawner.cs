using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace InteractableObjects.Core
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> pos;
        [SerializeField] private List<GameObject> obj;
        [SerializeField] private GameObject portal;
        [SerializeField] private SpawnPositions spawnPositions;
        [SerializeField] private SpawnType spawnType;

        private enum SpawnType
        {
            Points,
            Config
        }

        private void Start()
        {
            switch (spawnType)
            {
                case SpawnType.Points :
                    PointSpawning();
                    break;
                case SpawnType.Config :
                    ConfigSpawning();
                    break;
            }
        }

        private void PointSpawning()
        {
            var randomPos = Random.Range(0, pos.Count);
            Instantiate(portal, pos[randomPos]);

            for (int i = 0; i < pos.Count; i++)
            {
                if (i == randomPos) continue;
                
                var randomObj = Random.Range(0, obj.Count);
                Instantiate(obj[randomObj], pos[i]);
            }
        }

        private void ConfigSpawning()
        {
            var randomPos = Random.Range(0, spawnPositions.positions.Length);
            Instantiate(portal, spawnPositions.positions[randomPos], portal.transform.rotation);
            
            for (int i = 0; i < spawnPositions.positions.Length; i++)
            {
                if (i == randomPos) continue;
                
                var randomObj = Random.Range(0, obj.Count);
                Instantiate(obj[randomObj], spawnPositions.positions[i], obj[randomObj].transform.rotation);
            }
        }
    }
}
