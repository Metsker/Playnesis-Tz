using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> pos;
    [SerializeField] private List<GameObject> obj;

    private void Start()
    {
        for (int i = 0; i < pos.Count; i++)
        {
            var random = Random.Range(0, obj.Count);
            Instantiate(obj[random], pos[i]);
        }
    }
}
