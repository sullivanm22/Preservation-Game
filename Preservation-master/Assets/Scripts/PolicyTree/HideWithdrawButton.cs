using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWithdrawButton : MonoBehaviour
{
    public GameObject withdraw;
    public GameObject pass;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("pass") == 1 && PlayerPrefs.GetInt("withdraw") == 0)
        {
            pass.SetActive(false);
            withdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("pass") == 0 && PlayerPrefs.GetInt("withdraw") == 1)
        {
            withdraw.SetActive(false);
            pass.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickButton()
    {
        Debug.Log("withdraw button clicked");
        if (pass.activeSelf == false)
        {
            withdraw.SetActive(false);
            pass.SetActive(true);
            PlayerPrefs.SetInt("pass", 0); PlayerPrefs.SetInt("withdraw", 1);

            Debug.Log("withdraw should disappear and pass appear");
        }
    }
}
