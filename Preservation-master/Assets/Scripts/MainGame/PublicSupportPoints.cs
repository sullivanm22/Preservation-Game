using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PublicSupportPoints : MonoBehaviour
{
    public static int psp = 1;
    public Text pspCount;
    
    void Start()
    {
        PlayerPrefs.SetInt("psp", psp);
    }

    // Update is called once per frame
    void Update()
    {
        pspCount.text = psp.ToString();
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("day", psp);
    }

    public void NextDay()
    {
        //Checks to see if the Price Gouging Policy is passed. IF SO then you increase 2 public support points are added per day instead of 1
        if (PlayerPrefs.GetInt("priceGougingPass") == 1) {
            psp += 2;
        }
        else {
            psp++;
        }
    }
}
