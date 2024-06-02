using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameObject objectPool;
    void Start()
    {
        InvokeRepeating(nameof(SpawnProduct), 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnProduct()
    {
        GameObject pooledProduct = ObjectPooler.SharedInstance.GetPooledObject();

        if (pooledProduct != null)
        {
            pooledProduct.SetActive(true);
            pooledProduct.transform.position = GameObject.Find("SpawnPoint").transform.position;
        }
    }
}
