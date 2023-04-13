﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

    public GameObject pfNumberPopup;
    public Text moneyText;
    public Text happinessText;
    public Text policyPointsText;
    public Text healthyText;
    public Text infectedCountText;
    public Text deathCountText;
    public Text dayValText;
    public Text PolicymoneyText;
    public Text PolicypolicyPointsText;

    //These values are for the black container on the top of the policy menu
    public Text policyMoneyText;
    public Text policyHappinessText;
    public Text policyPolicyPointsText;
    public Text policyHealthyText;
    public Text policyInfectedCountText;
    public Text policyDeathCountText;
    public Text policyDayValueText;
    public Slider policyVaccineSlider;
    public Text policyVaccineProgressText;
    public MenusManager MM;

    public void spawnMoneyPopup(string val) {
        NumberPopup.Create(pfNumberPopup, moneyText.transform.position, val, moneyText.color);
    }
    public void spawnPolicyMoneyPopup(string val)
    {
        NumberPopup.Create(pfNumberPopup, PolicymoneyText.transform.position, val, PolicymoneyText.color);
    }

    public void spawnPolicyPointPopup(string val) {
        NumberPopup.Create(pfNumberPopup, policyPointsText.transform.position, val, policyPointsText.color);
    }

    public void spawnHealthyPopup(string val) {
        NumberPopup.Create(pfNumberPopup, healthyText.transform.position, val, healthyText.color);
    }

    public void spawnInfectedPopup(string val) {
        NumberPopup.Create(pfNumberPopup, infectedCountText.transform.position, val, infectedCountText.color);
    }

    public void spawnDeathPopup(string val) {
        NumberPopup.Create(pfNumberPopup, deathCountText.transform.position, val, deathCountText.color);
    }

    public void setMoneyText(string text) {
        moneyText.text = text;
    }
    public void setPolicyMoneyText(string text)
    {
        PolicymoneyText.text = text;
    }

    public void setHappinessText(string text)
    {
        happinessText.text = text;
    }

    public void setPPText(string text)
    {
        policyPointsText.text = text;
    }
    public void setPolicyPPText(string text)
    {
        PolicypolicyPointsText.text = text;
    }
 
    public void setHealthyText(string text)
    {
        healthyText.text = text;
    }

    public void setInfectedText(string text)
    {
        infectedCountText.text = text;
    }

    public void setDeathCountText(string text)
    {
        deathCountText.text = text;
    }

    public void setDayValText(string text) {
        dayValText.text = text;
    }
    public void setPolicyMenuText(){
        MM = MenusManager.getInstance();
        policyMoneyText.text = moneyText.text;
        policyHappinessText.text = happinessText.text;
        policyPolicyPointsText.text = policyPointsText.text;
        policyHealthyText.text = healthyText.text;
        policyInfectedCountText.text = infectedCountText.text;
        policyDeathCountText.text = deathCountText.text;
        policyDayValueText.text = dayValText.text;
        policyVaccineSlider = MM.getSlider();
        policyVaccineProgressText.text = MM.getProgressText();
    }
}
