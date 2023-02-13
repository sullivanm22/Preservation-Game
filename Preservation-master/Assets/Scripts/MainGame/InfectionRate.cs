using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectionRate : MonoBehaviour
{
    public static int infectionTracker = 100;
    public Text dayCount;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("infectionTracker", infectionTracker);
    }

    // Update is called once per frame
    void Update()
    {
        dayCount.text = infectionTracker.ToString() + "%";
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("infectionTracker", infectionTracker);
    }

    public void NextDay()
    {
        infectionTracker = 100 - PolicyPassed.policyMod;
    }
}
