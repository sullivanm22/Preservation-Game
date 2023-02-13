using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VpaDesOpen : MonoBehaviour
{

    //descriptions for each policy
    public GameObject VpaDescription;
    public GameObject OnlinePsaDescription;
    public GameObject RpsDescription;

    public void OpenPanel()
    {
        if (VpaDescription != null)
        {

            //booleans for whether each policy is description is open or not
            bool isActive = VpaDescription.activeSelf;
            bool onlineActive = OnlinePsaDescription.activeSelf;
            bool rpsActive = RpsDescription.activeSelf;

            //if the main policy is open, close it, and vice versa
            VpaDescription.SetActive(!isActive);

            //if the other policies are open
            if (onlineActive == true || rpsActive == true)
            {

                //closes the other policy descriptions and sets the main policy being pressed to open
                OnlinePsaDescription.SetActive(false);
                RpsDescription.SetActive(false);
                VpaDescription.SetActive(!isActive);
            }


        }
    }
}
