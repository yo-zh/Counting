using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public static Counter SharedInstance;


    [SerializeField]
    private Text CounterText;

    private int Count = 0;
    public void DecreaseCount() { Count--; CounterText.text = "Count : " + Count; }

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Product"))
        {
            Count++;
            CounterText.text = "Count : " + Count;
            other.gameObject.SetActive(false);
        }
        else
        {
            Count -= 5;
            CounterText.text = "Count : " + Count;
            other.gameObject.SetActive(false);
        }
    }
}
