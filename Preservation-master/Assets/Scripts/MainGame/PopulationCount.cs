using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationCount : MonoBehaviour
{
    public static int oPop = 1000000;
    public static int nPop;
    public Text popCount;

    void Start()
    {
        //oPop = 1000000;
        //popCount = GetComponent<Text>();
        PlayerPrefs.SetInt("population", oPop);
    }

    // Update is called once per frame
    void Update()
    {
        popCount.text = oPop.ToString();
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("population", oPop);
    }

    public void NextDay()
    {
        //if (oPop - DeadCount.dChange <= 500000)
        //{
            oPop -= DeadCount.dChange;
        //}
        //else
        //{
        //    Debug.Log("Population droppped too low, game over.");
        //}
    }
}
