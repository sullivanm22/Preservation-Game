using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class InfectedCount : MonoBehaviour
{
    public static int oInfected = 5;
    public static int nInfected = 5;
    public static int iChange = 0;
    public static int infAnimated = 0;
    public static int healthyAnimated = 0;
    public Text infectedCount;
    public Text infectedCountAnimated;
    public Text healthyAnimatedtext;


    void Start()
    {
        PlayerPrefs.SetInt("infected", oInfected);
    }

    // Update is called once per frame
    void Update()
    {
        infectedCount.text = nInfected.ToString();
        infectedCountAnimated.text = "+" +(iChange + infAnimated).ToString();
        healthyAnimatedtext.text = "-" + iChange.ToString();
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("infected", nInfected);
    }

    // Calculates the new number for the infected population (nInfected) as well as the number of infections that are new for that day (iChange).
    public void NextDay()
    {
        infAnimated = DeadCount.dChange;
       // healthyAnimated = nInfected;
        if (DayCounter.day < 10)
        {
            nInfected = Mathf.RoundToInt((float)(oInfected - DeadCount.dChange + (HealthyCount.healthy * (Random.Range(.001f, .005f) * ((float)InfectionRate.infectionTracker * .01)))));
        }
        else
        {
            nInfected = Mathf.RoundToInt((float)(oInfected - DeadCount.dChange + (HealthyCount.healthy * (Random.Range(.01f, .03f) * ((float)InfectionRate.infectionTracker * .01)))));
        }
        iChange = Mathf.Abs(nInfected - oInfected);
        oInfected = nInfected;
        
    }

}