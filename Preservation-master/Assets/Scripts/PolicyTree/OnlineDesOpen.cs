using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineDesOpen : MonoBehaviour
{

    //descriptions for each policy
    public GameObject VpaDescription;
    public GameObject OnlinePsaDescription;
    public GameObject RpsDescription;

    public void OpenPanel()
    {
        if (OnlinePsaDescription != null)
        {

            //booleans for whether each policy is description is open or not
            bool isActive = OnlinePsaDescription.activeSelf;
            bool vpaActive = VpaDescription.activeSelf;
            bool rpsActive = RpsDescription.activeSelf;

            //if the main policy is open, close it, and vice versa
            OnlinePsaDescription.SetActive(!isActive);

            //if the other policies are open
            if (vpaActive == true || rpsActive == true)
            {

                //closes the other policy descriptions and sets the main policy being pressed to open
                VpaDescription.SetActive(false);
                RpsDescription.SetActive(false);
                OnlinePsaDescription.SetActive(!isActive);
            }


        }
    }
}
