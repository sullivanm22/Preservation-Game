using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeDesOpen : MonoBehaviour
{

    //descriptions for each policy
    public GameObject TestingDescription;
    public GameObject IncomeDescription;
    public GameObject PriceDescription;
    public GameObject MaskDescription;
    public GameObject SchoolDescription;

    public void OpenPanel()
    {
        if (IncomeDescription != null)
        {

            //booleans for whether each policy is description is open or not
            bool isActive = IncomeDescription.activeSelf;
            bool testingActive = TestingDescription.activeSelf;
            bool priceActive = PriceDescription.activeSelf;
            bool maskActive = MaskDescription.activeSelf;
            bool schoolActive = SchoolDescription.activeSelf;

            //if the main policy is open, close it, and vice versa
            IncomeDescription.SetActive(!isActive);

            //if the other policies are open
            if (testingActive == true || priceActive == true || maskActive == true || schoolActive == true)
            {

                //closes the other policy descriptions and sets the main policy being pressed to open
                TestingDescription.SetActive(false);
                PriceDescription.SetActive(false);
                MaskDescription.SetActive(false);
                SchoolDescription.SetActive(false);
                IncomeDescription.SetActive(!isActive);
            }


        }
    }
}
