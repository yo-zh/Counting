using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductLifespan : MonoBehaviour
{
    [SerializeField] 
    private float lifespan;

    private float timer = 0;

    void Update()
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= lifespan)
            {
                timer = 0;
                gameObject.SetActive(false);
            }
        }
    }
}
