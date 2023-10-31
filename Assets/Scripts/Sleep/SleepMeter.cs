using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{

    public int sleeplevel = 100;

    public float timeCounter;

    public GameObject[] hearts;

    public void Update()
    {
        if (Time.time > timeCounter)
        {
            sleeplevel -= 1;
            timeCounter = Time.time + 5f;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (sleeplevel <= i * 20)
            {
                hearts[i].SetActive(false);
            }
            else
            {
                hearts[i].SetActive(true);
            }
        }
    }

    public void SleepUp()
    {
        if (sleeplevel < 100)
        {
            sleeplevel += 15;
            //sleepSoundEffect.Play();}
        }
    }

    public void SleepDown()
    {
        if (sleeplevel > 0)
        {
            sleeplevel -= 15;
            //sleepSoundEffect.Play();}

        }
    }
}
