using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<GameObject> pooledProducts;
    public List<GameObject> pooledBadProducts;
    public GameObject productToPool;
    public GameObject badProductToPool;
    public int amountToPool;
    public int amountToPoolBad;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledProducts = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(productToPool);
            obj.SetActive(false);
            pooledProducts.Add(obj);
            obj.transform.SetParent(this.transform);
        }

        pooledBadProducts = new List<GameObject>();
        for (int i = 0; i < amountToPoolBad; i++)
        {
            GameObject obj = Instantiate(badProductToPool);
            obj.SetActive(false);
            pooledBadProducts.Add(obj);
            obj.transform.SetParent(this.transform);
        }
    }

    public GameObject GetPooledProduct()
    {
        for (int i = 0; i < pooledProducts.Count; i++)
        { 
            if (!pooledProducts[i].activeInHierarchy)
            {
                return pooledProducts[i];
            }
        }
        return null;
    }

    public GameObject GetBadPooledProduct()
    {
        for (int i = 0; i < pooledBadProducts.Count; i++)
        { 
            if (!pooledBadProducts[i].activeInHierarchy)
            {
                return pooledBadProducts[i];
            }
        }
        return null;
    }


}
