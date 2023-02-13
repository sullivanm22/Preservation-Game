using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressDesOpen : MonoBehaviour
{

    //descriptions for each policy
    public GameObject VpaDescription;
    public GameObject OnlinePsaDescription;
    public GameObject RpsDescription;

    public void OpenPanel()
    {
        if (RpsDescription != null)
        {

            //booleans for whether each policy is description is open or not
            bool isActive = RpsDescription.activeSelf;
            bool onlineActive = OnlinePsaDescription.activeSelf;
            bool vpaActive = VpaDescription.activeSelf;

            //if the main policy is open, close it, and vice versa
            RpsDescription.SetActive(!isActive);

            //if the other policies are open
            if (onlineActive == true || vpaActive == true)
            {

                //closes the other policy descriptions and sets the main policy being pressed to open
                OnlinePsaDescription.SetActive(false);
                VpaDescription.SetActive(false);
                RpsDescription.SetActive(!isActive);
            }


        }
    }
}
