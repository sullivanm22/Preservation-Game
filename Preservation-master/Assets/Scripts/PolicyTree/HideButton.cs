using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideButton : MonoBehaviour
{

    public GameObject withdraw;
    public GameObject pass;

    // Start is called before the first frame update
    void Start()
    {
        withdraw.SetActive(false);
        pass.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("pass") == 1 && PlayerPrefs.GetInt("withdraw") == 0)
        {
            pass.SetActive(false);
            withdraw.SetActive(true);
        } else if (PlayerPrefs.GetInt("pass") == 0 && PlayerPrefs.GetInt("withdraw") == 1)
        {
            withdraw.SetActive(false);
            pass.SetActive(true);
        }        
    }

    public void clickButton()
    {
        Debug.Log("pass button clicked");
        if (pass.activeSelf == true)
        {
            withdraw.SetActive(true);
            pass.SetActive(false);
            PlayerPrefs.SetInt("pass", 1); PlayerPrefs.SetInt("withdraw", 0);
            Debug.Log("pass should disappear and withdraw appear");
        }
    }
}
