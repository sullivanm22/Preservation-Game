using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceDesOpen : MonoBehaviour
{
    public GameObject TestingDescription;
    public GameObject IncomeDescription;
    public GameObject PriceDescription;
    public GameObject MaskDescription;
    public GameObject SchoolDescription;

    public void OpenPanel()
    {
        if (PriceDescription != null)
        {

            //booleans for whether each policy is description is open or not
            bool isActive = PriceDescription.activeSelf;
            bool incomeActive = IncomeDescription.activeSelf;
            bool testingActive = TestingDescription.activeSelf;
            bool maskActive = MaskDescription.activeSelf;
            bool schoolActive = SchoolDescription.activeSelf;

            //if the main policy is open, close it, and vice versa
            PriceDescription.SetActive(!isActive);

            //if the other policies are open
            if (incomeActive == true || testingActive == true || maskActive == true || schoolActive == true)
            {

                //closes the other policy descriptions and sets the main policy being pressed to open
                IncomeDescription.SetActive(false);
                TestingDescription.SetActive(false);
                MaskDescription.SetActive(false);
                SchoolDescription.SetActive(false);
                PriceDescription.SetActive(!isActive);
            }


        }
    }
}
