using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenges : MonoBehaviour
{

    public GameObject Checkmark;
    // Start is called before the first frame update
    void Start()
    {
        Checkmark.SetActive(false);
    }

    // Update is called once per frame
    public void NextDay()
    {
        if (PlayerPrefs.GetInt("psp") >= 3 && PlayerPrefs.GetInt("infectionTracker") <= 95)
        {
            Checkmark.SetActive(true);
            PublicSupportPoints.psp += 3;
            Debug.Log("TEST");
        }
    }
}
