using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolDesOpen : MonoBehaviour
{

    //descriptions for each policy
    public GameObject TestingDescription;
    public GameObject IncomeDescription;
    public GameObject PriceDescription;
    public GameObject MaskDescription;
    public GameObject SchoolDescription;

    public void OpenPanel()
    {
        if (SchoolDescription != null)
        {

            //booleans for whether each policy is description is open or not
            bool isActive = SchoolDescription.activeSelf;
            bool incomeActive = IncomeDescription.activeSelf;
            bool priceActive = PriceDescription.activeSelf;
            bool maskActive = MaskDescription.activeSelf;
            bool testingActive = TestingDescription.activeSelf;


            //if the main policy is open, close it, and vice versa
            SchoolDescription.SetActive(!isActive);

            //if the other policies are open
            if (incomeActive == true || priceActive == true || maskActive == true || testingActive == true)
            {

                //closes the other policy descriptions and sets the main policy being pressed to open
                IncomeDescription.SetActive(false);
                PriceDescription.SetActive(false);
                MaskDescription.SetActive(false);
                TestingDescription.SetActive(false);
                SchoolDescription.SetActive(!isActive);
            }


        }
    }
}
