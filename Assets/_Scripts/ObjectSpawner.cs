using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _objectToSpawn; // Set in editor
    [SerializeField] private int _spawnCount = 2;

    public void SpawnObjects()
    {
        for (int i = 0; i < _spawnCount; i++)
        {
            Instantiate(_objectToSpawn, transform.position, Quaternion.identity);
        }
    }
}
