using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class PolicyPassed : MonoBehaviour
{
    public static int parksClosed = 0;
    public static int indoorBan = 0;
    public static int over100Ban = 0;
    public static int publicBan = 0;
    public static int intFlights = 0;
    public static int allFlights = 0;
    public static int borderClose = 0;
    public static int arrivalQuar = 0;
    public static int arrivaleTest = 0;
    public static int transportRed = 0;
    public static int transportCan = 0;
    public static int travelBan = 0;
    public static int dineInBan = 0;
    public static int bussinessClose = 0;
    public static int publicBroadcast = 0;
    public static int onlinePSA = 0;
    public static int pressStatement = 0;
    public static int testing = 0;
    public static int priceGouging = 0;
    public static int incomeSupport = 0;
    public static int schoolFunding = 0;
    public static int maskDistribution = 0;
    public static int policyMod = 0;

    public GameObject parksWithdraw;
    public GameObject parksPass;
    public GameObject indoorWithdraw;
    public GameObject indoorPass;
    public GameObject over100BanWithdraw;
    public GameObject over100BanPass;
    public GameObject publicBanWithdraw;
    public GameObject publicBanPass;
    public GameObject intFlightsWithdraw;
    public GameObject intFlightsPass;
    public GameObject allFlightsWithdraw;
    public GameObject allFlightsPass;
    public GameObject borderCloseWithdraw;
    public GameObject borderClosePass;
    public GameObject arrivalQuarWithdraw;
    public GameObject arrivalQuarPass;
    public GameObject arrivalTestWithdraw;
    public GameObject arrivalTestPass;
    public GameObject transportRedWithdraw;
    public GameObject transportRedPass;
    public GameObject transportCanWithdraw;
    public GameObject transportCanPass;
    public GameObject travelBanWithdraw;
    public GameObject travelBanPass;
    public GameObject dineInBanWithdraw;
    public GameObject dineInBanPass;
    public GameObject businessCloseWithdraw;
    public GameObject businessClosePass;
    public GameObject publicBroadcastWithdraw;
    public GameObject publicBroadcastPass;
    public GameObject onlinePSAWithdraw;
    public GameObject onlinePSAPass;
    public GameObject pressStatementWithdraw;
    public GameObject pressStatementPass;
    public GameObject testingWithdraw;
    public GameObject testingPass;
    public GameObject priceGougingWithdraw;
    public GameObject priceGougingPass;
    public GameObject incomeSupportWithdraw;
    public GameObject incomeSupportPass;
    public GameObject schoolFundingWithdaw;
    public GameObject schoolFundingPass;
    public GameObject maskDistributionWithdraw;
    public GameObject maskDistributionPass;


    // Start is called before the first frame update
    public void Start()
    {
        PlayerPrefs.SetInt("parksClosed", parksClosed);
        PlayerPrefs.SetInt("indoorBan", indoorBan);
        PlayerPrefs.SetInt("over100Ban", over100Ban);
        PlayerPrefs.SetInt("publicBan", publicBan);
        PlayerPrefs.SetInt("intFlights", intFlights);
        PlayerPrefs.SetInt("allFlights", allFlights);
        PlayerPrefs.SetInt("borderClose", borderClose);
        PlayerPrefs.SetInt("arrivalQuar", arrivalQuar);
        PlayerPrefs.SetInt("arrivaleTest", arrivaleTest);
        PlayerPrefs.SetInt("transportRed", transportRed);
        PlayerPrefs.SetInt("transportCan", transportCan);
        PlayerPrefs.SetInt("travelBan", travelBan);
        PlayerPrefs.SetInt("dineInBan", dineInBan);
        PlayerPrefs.SetInt("bussinessClose", bussinessClose);
        PlayerPrefs.SetInt("publicBroadcast", publicBroadcast);
        PlayerPrefs.SetInt("onlinePSA", onlinePSA);
        PlayerPrefs.SetInt("pressStatement", pressStatement);
        PlayerPrefs.SetInt("testing", testing);
        PlayerPrefs.SetInt("priceGouging", priceGouging);
        PlayerPrefs.SetInt("incomeSupport", incomeSupport);
        PlayerPrefs.SetInt("schoolFunding", schoolFunding);
        PlayerPrefs.SetInt("maskDistribution", maskDistribution);
        PlayerPrefs.SetInt("policyMod", policyMod);

        parksWithdraw.SetActive(false);
        parksPass.SetActive(true);
        indoorWithdraw.SetActive(false);
        indoorPass.SetActive(true);
        over100BanWithdraw.SetActive(false);
        over100BanPass.SetActive(true);
        publicBanWithdraw.SetActive(false);
        publicBanPass.SetActive(true);
        intFlightsWithdraw.SetActive(false);
        intFlightsPass.SetActive(true);
        allFlightsWithdraw.SetActive(false);
        allFlightsPass.SetActive(true);
        borderCloseWithdraw.SetActive(false);
        borderClosePass.SetActive(true);
        arrivalQuarWithdraw.SetActive(false);
        arrivalQuarPass.SetActive(true);
        arrivalTestWithdraw.SetActive(false);
        arrivalTestPass.SetActive(true);
        transportRedWithdraw.SetActive(false);
        transportRedPass.SetActive(true);
        transportCanWithdraw.SetActive(false);
        transportCanPass.SetActive(true);
        travelBanWithdraw.SetActive(false);
        travelBanPass.SetActive(true);
        dineInBanWithdraw.SetActive(false);
        dineInBanPass.SetActive(true);
        businessCloseWithdraw.SetActive(false);
        businessClosePass.SetActive(true);
        publicBroadcastWithdraw.SetActive(false);
        publicBroadcastPass.SetActive(true);
        onlinePSAWithdraw.SetActive(false);
        onlinePSAPass.SetActive(true);
        pressStatementWithdraw.SetActive(false);
        pressStatementPass.SetActive(true);
        testingWithdraw.SetActive(false);
        testingPass.SetActive(true);
        priceGougingWithdraw.SetActive(false);
        priceGougingPass.SetActive(true);
        incomeSupportWithdraw.SetActive(false);
        incomeSupportPass.SetActive(true);
        schoolFundingWithdaw.SetActive(false);
        schoolFundingPass.SetActive(true);
        maskDistributionWithdraw.SetActive(false);
        maskDistributionPass.SetActive(true);
}

    void Update()
    {
        if (PlayerPrefs.GetInt("parksPass") == 1 && PlayerPrefs.GetInt("parksWithdraw") == 0)
        {
            parksPass.SetActive(false);
            parksWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("parksPass") == 0 && PlayerPrefs.GetInt("parksWithdraw") == 1)
        {
            parksWithdraw.SetActive(false);
            parksPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("indoorPass") == 1 && PlayerPrefs.GetInt("indoorWithdraw") == 0)
        {
            indoorPass.SetActive(false);
            indoorWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("indoorPass") == 0 && PlayerPrefs.GetInt("indoorWithdraw") == 1)
        {
            indoorWithdraw.SetActive(false);
            indoorPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("over100BanPass") == 1 && PlayerPrefs.GetInt("over100BanWithdraw") == 0)
        {
            over100BanPass.SetActive(false);
            over100BanWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("over100BanPass") == 0 && PlayerPrefs.GetInt("over100BanWithdraw") == 1)
        {
            over100BanWithdraw.SetActive(false);
            over100BanPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("publicBanPass") == 1 && PlayerPrefs.GetInt("publicBanWithdraw") == 0)
        {
            publicBanPass.SetActive(false);
            publicBanWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("publicBanPass") == 0 && PlayerPrefs.GetInt("publicBanWithdraw") == 1)
        {
            publicBanWithdraw.SetActive(false);
            publicBanPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("intFlightsPass") == 1 && PlayerPrefs.GetInt("intFlightsWithdraw") == 0)
        {
            intFlightsPass.SetActive(false);
            intFlightsWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("intFlightsPass") == 0 && PlayerPrefs.GetInt("intFlightsWithdraw") == 1)
        {
            intFlightsWithdraw.SetActive(false);
            intFlightsPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("allFlightsPass") == 1 && PlayerPrefs.GetInt("allFlightsWithdraw") == 0)
        {
            allFlightsPass.SetActive(false);
            allFlightsWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("allFlightsPass") == 0 && PlayerPrefs.GetInt("allFlightsWithdraw") == 1)
        {
            allFlightsWithdraw.SetActive(false);
            allFlightsPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("borderClosePass") == 1 && PlayerPrefs.GetInt("borderCloseWithdraw") == 0)
        {
            borderClosePass.SetActive(false);
            borderCloseWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("borderClosePass") == 0 && PlayerPrefs.GetInt("borderCloseWithdraw") == 1)
        {
            borderCloseWithdraw.SetActive(false);
            borderClosePass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("arrivalQuarPass") == 1 && PlayerPrefs.GetInt("arrivalQuarWithdraw") == 0)
        {
            arrivalQuarPass.SetActive(false);
            arrivalQuarWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("arrivalQuarPass") == 0 && PlayerPrefs.GetInt("arrivalQuarWithdraw") == 1)
        {
            arrivalQuarWithdraw.SetActive(false);
            arrivalQuarPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("arrivalTestPass") == 1 && PlayerPrefs.GetInt("arrivalTestWithdraw") == 0)
        {
            arrivalTestPass.SetActive(false);
            arrivalTestWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("arrivalTestPass") == 0 && PlayerPrefs.GetInt("arrivalTestWithdraw") == 1)
        {
            arrivalTestWithdraw.SetActive(false);
            arrivalTestPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("transportRedPass") == 1 && PlayerPrefs.GetInt("transportRedWithdraw") == 0)
        {
            transportRedPass.SetActive(false);
            transportRedWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("transportRedPass") == 0 && PlayerPrefs.GetInt("transportRedWithdraw") == 1)
        {
            transportRedWithdraw.SetActive(false);
            transportRedPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("transportCanPass") == 1 && PlayerPrefs.GetInt("transportCanWithdraw") == 0)
        {
            transportCanPass.SetActive(false);
            transportCanWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("transportCanPass") == 0 && PlayerPrefs.GetInt("transportCanWithdraw") == 1)
        {
            transportCanWithdraw.SetActive(false);
            transportCanPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("travelBanPass") == 1 && PlayerPrefs.GetInt("travelBanWithdaw") == 0)
        {
            travelBanPass.SetActive(false);
            travelBanWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("travelBanPass") == 0 && PlayerPrefs.GetInt("travelBanWithdaw") == 1)
        {
            travelBanWithdraw.SetActive(false);
            travelBanPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("dineInBanPass") == 1 && PlayerPrefs.GetInt("dineInBanWithdraw") == 0)
        {
            dineInBanPass.SetActive(false);
            dineInBanWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("dineInBanPass") == 0 && PlayerPrefs.GetInt("dineInBanWithdraw") == 1)
        {
            dineInBanWithdraw.SetActive(false);
            dineInBanPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("businessClosePass") == 1 && PlayerPrefs.GetInt("businessCloseWithdraw") == 0)
        {
            businessClosePass.SetActive(false);
            businessCloseWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("businessClosePass") == 0 && PlayerPrefs.GetInt("businessCloseWithdraw") == 1)
        {
            businessCloseWithdraw.SetActive(false);
            businessClosePass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("publicBroadcastPass") == 1 && PlayerPrefs.GetInt("publicBroadcastWithdraw") == 0)
        {
            publicBroadcastPass.SetActive(false);
            publicBroadcastWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("publicBroadcastPass") == 0 && PlayerPrefs.GetInt("publicBroadcastWithdraw") == 1)
        {
            publicBroadcastWithdraw.SetActive(false);
            publicBroadcastPass.SetActive(true);
        }

        if(PlayerPrefs.GetInt("onlinePSAPass") == 1 && PlayerPrefs.GetInt("onlinePSAWithdraw") == 0)
        {
            onlinePSAPass.SetActive(false);
            onlinePSAWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("onlinePSAPass") == 0 && PlayerPrefs.GetInt("onlinePSAWithdraw") == 1)
        {
            onlinePSAWithdraw.SetActive(false);
            onlinePSAPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("pressStatementPass") == 1 && PlayerPrefs.GetInt("pressStatementWithdraw") == 0)
        {
            pressStatementPass.SetActive(false);
            pressStatementWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("pressStatementPass") == 0 && PlayerPrefs.GetInt("pressStatementWithdraw") == 1)
        {
            pressStatementWithdraw.SetActive(false);
            pressStatementPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("testingPass") == 1 && PlayerPrefs.GetInt("testingWithdraw") == 0)
        {
            testingPass.SetActive(false);
            testingWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("testingPass") == 0 && PlayerPrefs.GetInt("testingWithdraw") == 1)
        {
            testingWithdraw.SetActive(false);
            testingPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("priceGougingPass") == 1 && PlayerPrefs.GetInt("priceGougingWithdraw") == 0)
        {
            priceGougingPass.SetActive(false);
            priceGougingWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("priceGougingPass") == 0 && PlayerPrefs.GetInt("priceGougingWithdraw") == 1)
        {
            priceGougingWithdraw.SetActive(false);
            priceGougingPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("incomeSupportPass") == 1 && PlayerPrefs.GetInt("incomeSupportWithdraw") == 0)
        {
            incomeSupportPass.SetActive(false);
            incomeSupportWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("incomeSupportPass") == 0 && PlayerPrefs.GetInt("incomeSupportWithdraw") == 1)
        {
            incomeSupportWithdraw.SetActive(false);
            incomeSupportPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("schoolFundingPass") == 1 && PlayerPrefs.GetInt("schoolFundingWithdraw") == 0)
        {
            schoolFundingPass.SetActive(false);
            schoolFundingWithdaw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("schoolFundingPass") == 0 && PlayerPrefs.GetInt("schoolFundingWithdraw") == 1)
        {
            schoolFundingWithdaw.SetActive(false);
            schoolFundingPass.SetActive(true);
        }

        if (PlayerPrefs.GetInt("maskDistributionPass") == 1 && PlayerPrefs.GetInt("maskDistributionWithdraw") == 0)
        {
            maskDistributionPass.SetActive(false);
            maskDistributionWithdraw.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("maskDistributionPass") == 0 && PlayerPrefs.GetInt("maskDistributionWithdraw") == 1)
        {
            maskDistributionWithdraw.SetActive(false);
            maskDistributionPass.SetActive(true);
        }
    }

    public void OnDestroy()
    {
        PlayerPrefs.SetInt("parksClosed", parksClosed);
        PlayerPrefs.SetInt("indoorBan", indoorBan);
        PlayerPrefs.SetInt("over100Ban", over100Ban);
        PlayerPrefs.SetInt("publicBan", publicBan);
        PlayerPrefs.SetInt("intFlights", intFlights);
        PlayerPrefs.SetInt("allFlights", allFlights);
        PlayerPrefs.SetInt("borderClose", borderClose);
        PlayerPrefs.SetInt("arrivalQuar", arrivalQuar);
        PlayerPrefs.SetInt("arrivaleTest", arrivaleTest);
        PlayerPrefs.SetInt("transportRed", transportRed);
        PlayerPrefs.SetInt("transportCan", transportCan);
        PlayerPrefs.SetInt("travelBan", travelBan);
        PlayerPrefs.SetInt("dineInBan", dineInBan);
        PlayerPrefs.SetInt("bussinessClose", bussinessClose);
        PlayerPrefs.SetInt("publicBroadcast", publicBroadcast);
        PlayerPrefs.SetInt("onlinePSA", onlinePSA);
        PlayerPrefs.SetInt("pressStatement", pressStatement);
        PlayerPrefs.SetInt("testing", testing);
        PlayerPrefs.SetInt("priceGouging", priceGouging);
        PlayerPrefs.SetInt("incomeSupport", incomeSupport);
        PlayerPrefs.SetInt("schoolFunding", schoolFunding);
        PlayerPrefs.SetInt("maskDistribution", maskDistribution);
        PlayerPrefs.SetInt("policyMod", policyMod);

        
    }

    public void ParkClosedPass()
    {
        if (PublicSupportPoints.psp > 2 && parksPass.activeSelf == true)
        {
            parksClosed = 1;
            PublicSupportPoints.psp -= 3;
            parksWithdraw.SetActive(true);
            parksPass.SetActive(false);
            PlayerPrefs.SetInt("parksPass", 1); PlayerPrefs.SetInt("parksWithdraw", 0);
        }
    }

    public void IndoorBanPass()
    {
        //Checks if the play has GREATER or EQUAL to the cost of the policy (WILL ALSO DO THE SAME FOR THE METHODS BELOW WHEN PASSING** A POLICY)
        if (PublicSupportPoints.psp > 2 && indoorPass.activeSelf == true)
        {
            //TESTING UNITY ANALYTICS - should send an event whenever this policy is bought + print an OK to Console
            AnalyticsResult aResult = Analytics.CustomEvent("IndoorBanPass");
            Debug.Log("Analytics Result: " + aResult + " Policy Name: IndoorBanPass");

            indoorBan = 1;
            //SUBSTRACTS the cost of public support points from the users total (WILL DO THE SAME FOR THE METHODS BELOW WHEN PASSING** A POLICY)
            PublicSupportPoints.psp -= 3;
            indoorWithdraw.SetActive(true);
            indoorPass.SetActive(false);
            PlayerPrefs.SetInt("indoorPass", 1); PlayerPrefs.SetInt("indoorWithdraw", 0);
        }
    }

    public void Over100BanPass()
    {
        if (PublicSupportPoints.psp > 4 && over100BanPass.activeSelf == true)
        {
            over100Ban = 1;
            PublicSupportPoints.psp -= 5;
            over100BanWithdraw.SetActive(true);
            over100BanPass.SetActive(false);
            PlayerPrefs.SetInt("over100BanPass", 1); PlayerPrefs.SetInt("over100BanWithdraw", 0);
        }
    }

    public void PublicBanPass()
    {
        if (PublicSupportPoints.psp > 5 && publicBanPass.activeSelf == true)
        {
            publicBan = 1;
            PublicSupportPoints.psp -= 6;
            publicBanWithdraw.SetActive(true);
            publicBanPass.SetActive(false);
            PlayerPrefs.SetInt("publicBanPass", 1); PlayerPrefs.SetInt("publicBanWithdraw", 0);
        }
    }

    public void IntFlightsPass()
    {
        if (PublicSupportPoints.psp > 1 && intFlightsPass.activeSelf == true)
        {
            intFlights = 1;
            PublicSupportPoints.psp -= 2;
            intFlightsWithdraw.SetActive(true);
            intFlightsPass.SetActive(false);
            PlayerPrefs.SetInt("intFlightsPass", 1); PlayerPrefs.SetInt("intFlightsWithdraw", 0);
        }
    }

    public void AllFlightsPass()
    {
        if (PublicSupportPoints.psp > 2 && allFlightsPass.activeSelf == true)
        {
            allFlights = 1;
            PublicSupportPoints.psp -= 3;
            allFlightsWithdraw.SetActive(true);
            allFlightsPass.SetActive(false);
            PlayerPrefs.SetInt("allFlightsPass", 1); PlayerPrefs.SetInt("allFlightsWithdraw", 0);
        }
    }

    public void BorderClosePass()
    {
        if (PublicSupportPoints.psp > 3 && borderClosePass.activeSelf == true)
        {
            borderClose = 1;
            arrivalQuar = 1;
            arrivaleTest = 1;
            allFlights = 1;
            intFlights = 1;
            PublicSupportPoints.psp -= 4;
            borderCloseWithdraw.SetActive(true);
            borderClosePass.SetActive(false);
            PlayerPrefs.SetInt("borderClosePass", 1); PlayerPrefs.SetInt("borderCloseWithdraw", 0);
        }
    }

    public void ArrivalQuarPass()
    {
        if (PublicSupportPoints.psp > 1 && arrivalQuarPass.activeSelf == true)
        {
            arrivalQuar = 1;
            PublicSupportPoints.psp -= 2;
            arrivalQuarWithdraw.SetActive(true);
            arrivalQuarPass.SetActive(false);
            PlayerPrefs.SetInt("arrivalQuarPass", 1); PlayerPrefs.SetInt("arrivalQuarWithdraw", 0);
        }
    }

    public void ArrivalTestPass()
    {
        if (PublicSupportPoints.psp > 1 && arrivalTestPass.activeSelf == true)
        {
            arrivaleTest = 1;
            PublicSupportPoints.psp -= 2;
            arrivalTestWithdraw.SetActive(true);
            arrivalTestPass.SetActive(false);
            PlayerPrefs.SetInt("arrivalTestPass", 1); PlayerPrefs.SetInt("arrivalTestWithdraw", 0);
        }
    }

    public void TransportRedPass()
    {
        if (PublicSupportPoints.psp > 1 && transportRedPass.activeSelf == true)
        {
            transportRed = 1;
            PublicSupportPoints.psp -= 2;
            transportRedWithdraw.SetActive(true);
            transportRedPass.SetActive(false);
            PlayerPrefs.SetInt("transportRedPass", 1); PlayerPrefs.SetInt("transportRedWithdraw", 0);
        }
    }

    public void TransportCanPass()
    {
        if (PublicSupportPoints.psp > 1 && transportCanPass.activeSelf == true)
        {
            transportCan = 1;
            PublicSupportPoints.psp -= 2;
            transportCanWithdraw.SetActive(true);
            transportCanPass.SetActive(false);
            PlayerPrefs.SetInt("transportCanPass", 1); PlayerPrefs.SetInt("transportCanWithdraw", 0);
        }
    }

    public void TravelBanPass()
    {
        if (PublicSupportPoints.psp > 1 && travelBanPass.activeSelf == true)
        {
            travelBan = 1;
            PublicSupportPoints.psp -= 2;
            travelBanWithdraw.SetActive(true);
            travelBanPass.SetActive(false);
            PlayerPrefs.SetInt("travelBanPass", 1); PlayerPrefs.SetInt("travelBanWithdaw", 0);
        }
    }

    public void DineInBanPass()
    {
        if (PublicSupportPoints.psp > 2 && dineInBanPass.activeSelf == true)
        {
            dineInBan = 1;
            PublicSupportPoints.psp -= 3;
            dineInBanWithdraw.SetActive(true);
            dineInBanPass.SetActive(false);
            PlayerPrefs.SetInt("dineInBanPass", 1); PlayerPrefs.SetInt("dineInBanWithdraw", 0);
        }
    }

    public void BussinessClosePass()
    {
        if (PublicSupportPoints.psp > 3 && businessClosePass.activeSelf == true)
        {
            bussinessClose = 1;
            PublicSupportPoints.psp -= 4;
            businessCloseWithdraw.SetActive(true);
            businessClosePass.SetActive(false);
            PlayerPrefs.SetInt("businessClosePass", 1); PlayerPrefs.SetInt("businessCloseWithdraw", 0);
        }
    }

    public void PublicBroadcastPass()
    {
        if (PublicSupportPoints.psp > 0 && publicBroadcastPass.activeSelf == true)
        {
            publicBroadcast = 1;
            PublicSupportPoints.psp -= 1;
            publicBroadcastWithdraw.SetActive(true);
            publicBroadcastPass.SetActive(false);
            PlayerPrefs.SetInt("publicBroadcastPass", 1); PlayerPrefs.SetInt("publicBroadcastWithdraw", 0);
        }
    }

    public void OnlinePSAPass()
    {
        if (PublicSupportPoints.psp > 1 && onlinePSAPass.activeSelf == true)
        {
            onlinePSA = 1;
            PublicSupportPoints.psp -= 2;
            onlinePSAWithdraw.SetActive(true);
            onlinePSAPass.SetActive(false);
            PlayerPrefs.SetInt("onlinePSAPass", 1); PlayerPrefs.SetInt("onlinePSAWithdraw", 0);
        }
    }

    public void PressStatementPass()
    {
        if (PublicSupportPoints.psp > 1 && pressStatementPass.activeSelf == true)
        {
            pressStatement = 1;
            PublicSupportPoints.psp -= 2;
            pressStatementWithdraw.SetActive(true);
            pressStatementPass.SetActive(false);
            PlayerPrefs.SetInt("pressStatementPass", 1); PlayerPrefs.SetInt("pressStatementWithdraw", 0);
        }
    }

    public void TestingPass()
    {
        if (PublicSupportPoints.psp > 4 && testingPass.activeSelf == true)
        {
            testing = 1;
            PublicSupportPoints.psp -= 5;
            testingWithdraw.SetActive(true);
            testingPass.SetActive(false);
            PlayerPrefs.SetInt("testingPass", 1); PlayerPrefs.SetInt("testingWithdraw", 0);
        }
    }

    public void PriceGougingPass()
    {
        if (PublicSupportPoints.psp > 2 && priceGougingPass.activeSelf == true)
        {
            priceGouging = 1;
            PublicSupportPoints.psp -= 3;
            priceGougingWithdraw.SetActive(true);
            priceGougingPass.SetActive(false);
            PlayerPrefs.SetInt("priceGougingPass", 1); PlayerPrefs.SetInt("priceGougingWithdraw", 0);
        }
    }

    public void IncomeSupportPass()
    {
        if (PublicSupportPoints.psp > 4 && incomeSupportPass.activeSelf == true)
        {
            incomeSupport = 1;
            PublicSupportPoints.psp -= 5;
            incomeSupportWithdraw.SetActive(true);
            incomeSupportPass.SetActive(false);
            PlayerPrefs.SetInt("incomeSupportPass", 1); PlayerPrefs.SetInt("incomeSupportWithdraw", 0);
        }
    }

    public void SchoolFundingPass()
    {
        if (PublicSupportPoints.psp > 9 && schoolFundingPass.activeSelf == true)
        {
            schoolFunding = 1;
            PublicSupportPoints.psp -= 10;
            schoolFundingWithdaw.SetActive(true);
            schoolFundingPass.SetActive(false);
            PlayerPrefs.SetInt("schoolFundingPass", 1); PlayerPrefs.SetInt("schoolFundingWithdraw", 0);
        }
    }

    public void MaskDistributionPass()
    {
        if (PublicSupportPoints.psp > 5 && maskDistributionPass.activeSelf == true)
        {
            maskDistribution = 1;
            PublicSupportPoints.psp -= 6;
            maskDistributionWithdraw.SetActive(true);
            maskDistributionPass.SetActive(false);
            PlayerPrefs.SetInt("maskDistributionPass", 1); PlayerPrefs.SetInt("maskDistributionWithdraw", 0);
        }
    }

    public void ParkClosedWithdraw()
    {
        if (parksPass.activeSelf == false)
        {
            //RETURNS back some public support points to the user when policy is withdrawn (WILL DO THE SAME FOR THE METHODS BELOW WHEN WITHDRAWING** A POLICY)
            PublicSupportPoints.psp += 1;
            parksWithdraw.SetActive(false);
            parksPass.SetActive(true);
            PlayerPrefs.SetInt("parksPass", 0); PlayerPrefs.SetInt("parksWithdraw", 1);
        }
        parksClosed = 0;
    }

    public void IndoorBanWithdraw()
    {
        if (indoorPass.activeSelf == false)
        {
            PublicSupportPoints.psp += 1;
            indoorWithdraw.SetActive(false);
            indoorPass.SetActive(true);
            PlayerPrefs.SetInt("indoorPass", 0); PlayerPrefs.SetInt("indoorWithdraw", 1);
        }
        indoorBan = 0;
    }

    public void Over100BanWithdraw()
    {
        if (over100BanPass.activeSelf == false)
        {
            PublicSupportPoints.psp += 2;
            over100BanWithdraw.SetActive(false);
            over100BanPass.SetActive(true);
            PlayerPrefs.SetInt("over100BanPass", 0); PlayerPrefs.SetInt("over100BanWithdraw", 1);
        }
        over100Ban = 0;
    }

    public void PublicBanWithdraw()
    {
        if (publicBanPass.activeSelf == false)
        {
            PublicSupportPoints.psp += 3;
            publicBanWithdraw.SetActive(false);
            publicBanPass.SetActive(true);
            PlayerPrefs.SetInt("publicBanPass", 0); PlayerPrefs.SetInt("publicBanWithdraw", 1);
        }
        publicBan = 0;
    }

    public void IntFlightsWithdraw()
    {
        if (intFlightsPass.activeSelf == false)
        {
            PublicSupportPoints.psp += 1;
            intFlightsWithdraw.SetActive(false);
            intFlightsPass.SetActive(true);
            PlayerPrefs.SetInt("intFlightsPass", 0); PlayerPrefs.SetInt("intFlightsWithdraw", 1);
        }
        intFlights = 0;
    }

    public void AllFlightsWithdraw()
    {
        if (allFlightsPass.activeSelf == false)
        {
            PublicSupportPoints.psp += 2;
            allFlightsWithdraw.SetActive(false);
            allFlightsPass.SetActive(true);
            PlayerPrefs.SetInt("allFlightsPass", 0); PlayerPrefs.SetInt("allFlightsWithdraw", 1);
        }
        allFlights = 0;
    }

    public void BorderCloseWithdraw()
    {
        if (borderClosePass.activeSelf == false)
        {
            PublicSupportPoints.psp += 2;
            borderCloseWithdraw.SetActive(false);
            borderClosePass.SetActive(true);
            PlayerPrefs.SetInt("borderClosePass", 0); PlayerPrefs.SetInt("borderCloseWithdraw", 1);
        }
        borderClose = 0;
    }

    public void ArrivalQuarWithdraw()
    {
        if (arrivalQuarPass.activeSelf == false)
        {
            PublicSupportPoints.psp += 1;
            arrivalQuarWithdraw.SetActive(false);
            arrivalQuarPass.SetActive(true);
            PlayerPrefs.SetInt("arrivalQuarPass", 0); PlayerPrefs.SetInt("arrivalQuarWithdraw", 1);
        }
        arrivalQuar = 0;
    }

    public void ArrivalTestWithdraw()
    {
        if (arrivalTestPass.activeSelf == false)
        {
            PublicSupportPoints.psp += 1;
            arrivalTestWithdraw.SetActive(false);
            arrivalTestPass.SetActive(true);
            PlayerPrefs.SetInt("arrivalTestPass", 0); PlayerPrefs.SetInt("arrivalTestWithdraw", 1);
        }
        arrivaleTest = 0;
    }

    public void TransportRedWithdraw()
    {
        if (transportRedPass.activeSelf == false)
        {
            transportRedWithdraw.SetActive(false);
            transportRedPass.SetActive(true);
            PlayerPrefs.SetInt("transportRedPass", 0); PlayerPrefs.SetInt("transportRedWithdraw", 1);
        }
        transportRed = 0;
    }

    public void TransportCanWithdraw()
    {
        if (transportCanPass.activeSelf == false)
        {
            PublicSupportPoints.psp += 1;
            transportCanWithdraw.SetActive(false);
            transportCanPass.SetActive(true);
            PlayerPrefs.SetInt("transportCanPass", 0); PlayerPrefs.SetInt("transportCanWithdraw", 1);
        }
        transportCan = 0;
    }

    public void TravelBanWithdraw()
    {
        if (travelBanPass.activeSelf == false)
        {
            PublicSupportPoints.psp += 1;
            travelBanWithdraw.SetActive(false);
            travelBanPass.SetActive(true);
            PlayerPrefs.SetInt("travelBanPass", 0); PlayerPrefs.SetInt("travelBanWithdraw", 1);
        }
        travelBan = 0;
    }

    public void DineInBanWithdraw()
    {
        if (dineInBanPass.activeSelf == false)
        {
            PublicSupportPoints.psp += 1;
            dineInBanWithdraw.SetActive(false);
            dineInBanPass.SetActive(true);
            PlayerPrefs.SetInt("dineInBanPass", 0); PlayerPrefs.SetInt("dineInBanWithdraw", 1);
        }
        dineInBan = 0;
    }

    public void BussinessCloseWithdraw()
    {
        if (businessClosePass.activeSelf == false)
        {
            PublicSupportPoints.psp += 2;
            businessCloseWithdraw.SetActive(false);
            businessClosePass.SetActive(true);
            PlayerPrefs.SetInt("businessClosePass", 0); PlayerPrefs.SetInt("businessCloseWithdraw", 1);
        }
        bussinessClose = 0;
    }

    public void PublicBroadcastWithdraw()
    {
        if (publicBroadcastPass.activeSelf == false)
        {
            publicBroadcastWithdraw.SetActive(false);
            publicBroadcastPass.SetActive(true);
            PlayerPrefs.SetInt("publicBroadcastPass", 0); PlayerPrefs.SetInt("publicBroadcastWithdraw", 1);
        }
        publicBroadcast = 0;
    }

    public void OnlinePSAWithdraw()
    {
        if (onlinePSAPass.activeSelf == false)
        {
            onlinePSAWithdraw.SetActive(false);
            onlinePSAPass.SetActive(true);
            PlayerPrefs.SetInt("onlinePSAPass", 0); PlayerPrefs.SetInt("onlinePSAWithdraw", 1);
        }
        onlinePSA = 0;
    }

    public void PressStatementWithdraw()
    {
        if (pressStatementPass.activeSelf == false)
        {
            pressStatementWithdraw.SetActive(false);
            pressStatementPass.SetActive(true);
            PlayerPrefs.SetInt("pressStatementPass", 0); PlayerPrefs.SetInt("pressStatementWithdraw", 1);
        }
        pressStatement = 0;
    }

    public void TestingWithdraw()
    {
        if (testingPass.activeSelf == false)
        {
            PublicSupportPoints.psp += 2;
            testingWithdraw.SetActive(false);
            testingPass.SetActive(true);
            PlayerPrefs.SetInt("testingPass", 0); PlayerPrefs.SetInt("testingWithdraw", 1);
        }
        testing = 0;
    }

    public void PriceGougingWithdraw()
    {
        if (priceGougingPass.activeSelf == false)
        {
            PublicSupportPoints.psp += 1;
            priceGougingWithdraw.SetActive(false);
            priceGougingPass.SetActive(true);
            PlayerPrefs.SetInt("priceGougingPass", 0); PlayerPrefs.SetInt("priceGougingWithdraw", 1);
        }
        priceGouging = 0;
    }

    public void IncomeSupportWithdraw()
    {
        if (incomeSupportPass.activeSelf == false)
        {
            PublicSupportPoints.psp += 2;
            incomeSupportWithdraw.SetActive(false);
            incomeSupportPass.SetActive(true);
            PlayerPrefs.SetInt("incomeSupportPass", 0); PlayerPrefs.SetInt("incomeSupportWithdraw", 1);
        }
        incomeSupport = 0;
    }

    public void SchoolFundingWithdraw()
    {
        if (schoolFundingPass.activeSelf == false)
        {
            PublicSupportPoints.psp += 4;
            schoolFundingWithdaw.SetActive(false);
            schoolFundingPass.SetActive(true);
            PlayerPrefs.SetInt("schoolFundingPass", 0); PlayerPrefs.SetInt("schoolFundingWithdraw", 1);
        }
        schoolFunding = 0;
    }

    public void MaskDistributionWithdraw()
    {
        if (maskDistributionPass.activeSelf == false)
        {
            PublicSupportPoints.psp += 3;
            maskDistributionWithdraw.SetActive(false);
            maskDistributionPass.SetActive(true);
            PlayerPrefs.SetInt("maskDistributionPass", 0); PlayerPrefs.SetInt("maskDistributionWithdraw", 1);
        }
        maskDistribution = 0;
    }

    public void InfectionRateCalc()
    {
        policyMod = 0;
        if (parksClosed == 1)
        {
            policyMod += 5;
        }
        if (indoorBan == 1)
        {
            policyMod += 5;
        }
        if (over100Ban == 1)
        {
            policyMod += 6;
        }
        if (publicBan == 1) 
        {
            policyMod += 7;
        }
        if (intFlights == 1)
        {
            policyMod += 3;
        }
        if (allFlights == 1)
        {
            policyMod += 3;
        }
        if (borderClose == 1)
        {
            policyMod += 1;
        }
        if (arrivalQuar == 1)
        {
            policyMod += 3;
        }
        if (arrivaleTest == 1)
        {
            policyMod += 3;
        }
        if (transportRed == 1)
        {
            policyMod += 3;
        }
        if (transportCan == 1)
        {
            policyMod += 3;
        }
        if (travelBan == 1)
        {
            policyMod += 3;
        }
        if (dineInBan == 1)
        {
            policyMod += 5;
        }
        if (bussinessClose == 1)
        {
            policyMod += 7;
        }
        if (publicBroadcast == 1)
        {
            policyMod += 3;
        }
        if (onlinePSA == 1)
        {
            policyMod += 2;
        }
        if (pressStatement == 1)
        {
            policyMod += 3;
        }
        if (testing == 1)
        {
            policyMod += 6;
        }
        if (incomeSupport == 1)
        {
            policyMod += 5;
        }
        if (schoolFunding == 1)
        {
            policyMod += 17;
        }
        if (maskDistribution == 1)
        {
            policyMod += 7;
        }
    }
}
