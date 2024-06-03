﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text CounterText;

    private int Count = 0;

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
