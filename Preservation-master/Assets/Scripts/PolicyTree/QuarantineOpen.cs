﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarantineOpen : MonoBehaviour
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
        if (QuarantineDescription != null)
        {

            //booleans for whether each policy is description is open or not
            bool isActive = QuarantineDescription.activeSelf;
            bool indoorActive = IndoorDescription.activeSelf;
            bool over100Active = Over100Descriptoon.activeSelf;
            bool publicActive = PublicDescription.activeSelf;
            bool nonEssentialTravelActive = NonEssentialTravelDescription.activeSelf;
            bool reduceTransitActive = ReduceTransitDescription.activeSelf;
            bool cancelTransitActive = CancelTransitDescription.activeSelf;
            bool parksActive = ParksDescription.activeSelf;
            bool testActive = TestDescription.activeSelf;
            bool interActive = InternationalDescription.activeSelf;
            bool allFlightsActive = AllFlightsDescription.activeSelf;
            bool bordersActive = BordersDescription.activeSelf;
            bool diningActive = DiningDescription.activeSelf;
            bool businessActive = BusinessDescription.activeSelf;

            //if the main policy is open, close it, and vice versa
            QuarantineDescription.SetActive(!isActive);

            //if the other policies are open
            if (indoorActive == true || over100Active == true || publicActive == true ||
                nonEssentialTravelActive == true || reduceTransitActive == true || cancelTransitActive == true ||
                parksActive == true || testActive == true || interActive == true ||
                allFlightsActive == true || bordersActive == true || diningActive == true || businessActive == true)
            {

                //closes the other policy descriptions and sets the main policy being pressed to open
                IndoorDescription.SetActive(false);
                Over100Descriptoon.SetActive(false);
                PublicDescription.SetActive(false);
                NonEssentialTravelDescription.SetActive(false);
                ReduceTransitDescription.SetActive(false);
                CancelTransitDescription.SetActive(false);
                ParksDescription.SetActive(false);
                TestDescription.SetActive(false);
                InternationalDescription.SetActive(false);
                AllFlightsDescription.SetActive(false);
                BordersDescription.SetActive(false);
                DiningDescription.SetActive(false);
                BusinessDescription.SetActive(false);
                QuarantineDescription.SetActive(!isActive);
            }
        }
    }
}
