using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyOpen : MonoBehaviour
{

    //descriptions for each policy
    public GameObject VpaDescription;
    public GameObject OnlinePsaDescription;
    public GameObject RpsDescription;
    public GameObject Empty;

    public void OpenPanel()
    {
        if (Empty != null)
        {

            //booleans for whether each policy is description is open or not
            bool isActive = Empty.activeSelf;
            bool onlineActive = OnlinePsaDescription.activeSelf;
            bool vpaActive = VpaDescription.activeSelf;
            bool rpsActive = RpsDescription.activeSelf;

            //if the main policy is open, close it, and vice versa
            Empty.SetActive(!isActive);

            //if the other policies are open
            if (onlineActive == true || vpaActive == true || rpsActive == true)
            {

                //closes the other policy descriptions and sets the main policy being pressed to open
                RpsDescription.SetActive(false);
                OnlinePsaDescription.SetActive(false);
                VpaDescription.SetActive(false);
                Empty.SetActive(!isActive);
            }


        }
    }
}
