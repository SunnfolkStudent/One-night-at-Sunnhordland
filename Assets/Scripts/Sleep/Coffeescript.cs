using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Coffeescript : MonoBehaviour
{
    public float coffeeTimeCounter;
    private SleepMeter _sleepMeter;
    private bool _coffee;
    void Start()
    {
        _sleepMeter = GetComponent<SleepMeter>();
        
    }

    private void OnMouseDown()
    {
        if (_coffee)
        {
            _sleepMeter.SleepUp();
            _coffee = false;
        }

    }


    public void Update()
    {
        if (Time.time > coffeeTimeCounter)
        {
            _coffee = true;
            coffeeTimeCounter = Time.time + 15f;
        }
    }
    
}
