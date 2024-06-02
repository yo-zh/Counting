using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductLifespan : MonoBehaviour
{
    [SerializeField] 
    private float lifespan;

    [SerializeField]
    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifespan)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        timer = 0;
    }
}
