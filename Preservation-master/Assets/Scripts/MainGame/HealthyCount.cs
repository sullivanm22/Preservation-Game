using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthyCount : MonoBehaviour
{
    public static int healthy = 999995;
    public static int healthyAnimated = 0;
    public Text healthyCount;
    public Text healthyCountAnimated;
    void Start()
    {
        //healthy = 999995;
        //healthyCount = GetComponent<Text>();
        PlayerPrefs.SetInt("healthy", healthy);
    }

    // Update is called once per frame
    void Update()
    {
        healthyCount.text = healthy.ToString();
        healthyCountAnimated.text = "-" + healthyAnimated.ToString();
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("healthy", healthy);
    }

    public void NextDay()
    {
        healthyAnimated = InfectedCount.nInfected;
        healthy = PopulationCount.oPop - InfectedCount.nInfected;
        
    }
}
