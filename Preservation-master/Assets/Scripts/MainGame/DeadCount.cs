using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadCount : MonoBehaviour
{
    public static int oDead = 0;
    public static int nDead = 0;
    public static int dChange = 0;
    public Text deadCount;
    public Text deadCountanimation;

    void Start()
    {
        //nDead = 0;
        //oDead = 0;
        //dChange = 0;
        //deadCount = GetComponent<Text>();
        PlayerPrefs.SetInt("dead", oDead);
    }

    // Update is called once per frame
    void Update()
    {
        deadCount.text = nDead.ToString();
        deadCountanimation.text = "+" + dChange.ToString();
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("dead", nDead);
    }

    public void NextDay()
    {
        nDead = Mathf.RoundToInt((float)(oDead + (InfectedCount.oInfected * Random.Range(.005f, .01f))));
        dChange = Mathf.Abs(nDead - oDead);
        oDead = nDead;
    }
}