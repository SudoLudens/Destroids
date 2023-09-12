using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDestroy : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn; // Set in editor
    [SerializeField] private int spawnCount = 2;

    private void OnDestroy()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
