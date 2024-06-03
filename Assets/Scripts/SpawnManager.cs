using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject objectPool;
    private GameObject[] spawnPoints;

    [SerializeField] private float spawnRate = 5.0f;
    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        InvokeRepeating(nameof(SpawnProduct), 0, spawnRate);
    }

    void Update()
    {
        
    }

    private GameObject RandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        GameObject spawnPoint = spawnPoints[randomIndex];

        return spawnPoint;
    }

    private void SpawnProduct()
    {
        GameObject spawnPoint = RandomSpawnPoint();
        GameObject pooledProduct = ObjectPooler.SharedInstance.GetPooledObject();

        if (pooledProduct != null)
        {
            pooledProduct.SetActive(true);
            pooledProduct.transform.position = spawnPoint.transform.position;
        }
    }
}
