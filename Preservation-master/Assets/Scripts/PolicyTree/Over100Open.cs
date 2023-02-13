using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Over100Open : MonoBehaviour
{

    //descriptions for each policy
    public GameObject ParksDescription;
    public GameObject IndoorDescription;
    public GameObject Over100Descriptoon;
    public GameObject PublicDescription;
    public GameObject NonEssentialTravelDescription;
    public GameObject ReduceTransitDescription;
    public GameObject CancelTransitDescription;
    public GameObject QuarantineDescription;
    public GameObject TestDescription;
    public GameObject InternationalDescription;
    public GameObject AllFlightsDescription;
    public GameObject BordersDescription;
    public GameObject DiningDescription;
    public GameObject BusinessDescription;

    public void OpenPanel()
    {
        if (Over100Descriptoon != null)
        {

            //booleans for whether each policy is description is open or not
            bool isActive = Over100Descriptoon.activeSelf;
            bool indoorActive = IndoorDescription.activeSelf;
            bool parksActive = ParksDescription.activeSelf;
            bool publicActive = PublicDescription.activeSelf;
            bool nonEssentialTravelActive = NonEssentialTravelDescription.activeSelf;
            bool reduceTransitActive = ReduceTransitDescription.activeSelf;
            bool cancelTransitActive = CancelTransitDescription.activeSelf;
            bool quarantineActive = QuarantineDescription.activeSelf;
            bool testActive = TestDescription.activeSelf;
            bool interActive = InternationalDescription.activeSelf;
            bool allFlightsActive = AllFlightsDescription.activeSelf;
            bool bordersActive = BordersDescription.activeSelf;
            bool diningActive = DiningDescription.activeSelf;
            bool businessActive = BusinessDescription.activeSelf;

            //if the main policy is open, close it, and vice versa
            Over100Descriptoon.SetActive(!isActive);

            //if the other policies are open
            if (indoorActive == true || parksActive == true || publicActive == true ||
                nonEssentialTravelActive == true || reduceTransitActive == true || cancelTransitActive == true ||
                quarantineActive == true || testActive == true || interActive == true ||
                allFlightsActive == true || bordersActive == true || diningActive == true || businessActive == true)
            {

                //closes the other policy descriptions and sets the main policy being pressed to open
                IndoorDescription.SetActive(false);
                ParksDescription.SetActive(false);
                PublicDescription.SetActive(false);
                NonEssentialTravelDescription.SetActive(false);
                ReduceTransitDescription.SetActive(false);
                CancelTransitDescription.SetActive(false);
                QuarantineDescription.SetActive(false);
                TestDescription.SetActive(false);
                InternationalDescription.SetActive(false);
                AllFlightsDescription.SetActive(false);
                BordersDescription.SetActive(false);
                DiningDescription.SetActive(false);
                BusinessDescription.SetActive(false);
                Over100Descriptoon.SetActive(!isActive);
            }
        }
    }
}
