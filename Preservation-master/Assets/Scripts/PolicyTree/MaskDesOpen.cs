using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskDesOpen : MonoBehaviour
{

    //descriptions for each policy
    public GameObject TestingDescription;
    public GameObject IncomeDescription;
    public GameObject PriceDescription;
    public GameObject MaskDescription;
    public GameObject SchoolDescription;

    public void OpenPanel()
    {
        if (MaskDescription != null)
        {

            //booleans for whether each policy is description is open or not
            bool isActive = MaskDescription.activeSelf;
            bool incomeActive = IncomeDescription.activeSelf;
            bool priceActive = PriceDescription.activeSelf;
            bool testingActive = TestingDescription.activeSelf;
            bool schoolActive = SchoolDescription.activeSelf;

            //if the main policy is open, close it, and vice versa
            MaskDescription.SetActive(!isActive);

            //if the other policies are open
            if (incomeActive == true || priceActive == true || testingActive == true || schoolActive == true)
            {

                //closes the other policy descriptions and sets the main policy being pressed to open
                IncomeDescription.SetActive(false);
                PriceDescription.SetActive(false);
                TestingDescription.SetActive(false);
                SchoolDescription.SetActive(false);
                MaskDescription.SetActive(!isActive);
            }


        }
    }
}
