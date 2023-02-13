using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCounter : MonoBehaviour
{

    public static int day = 0;
    public Text dayCount;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("day", day);
    }

    // Update is called once per frame
    void Update()
    {
        dayCount.text = day.ToString();
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("day", day);
    }

    public void NextDay()
    {
        day++;
    }
}
