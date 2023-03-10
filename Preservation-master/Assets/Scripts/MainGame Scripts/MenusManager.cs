using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleSheetsForUnity;

public class MenusManager : MonoBehaviour
{
    public Slider VaccineSlider;
    public Text Progress;
    public GameObject mainGame;
    public GameObject pauseMenu;
    public GameObject policyMenu;
    public GameObject hospitalTree;
    public GameObject restrictionsTree;
    public GameObject PSATree;
    public GameObject travelTree;
    public GameObject sickTree;

    private static GameManager gm = GameManager.getInstance();
    
    public void showPauseMenu() {
        pauseMenu.SetActive(true);
    }

    public void showSlider() {
        VaccineSlider.gameObject.SetActive(true);
    }

    public void updateSlider(){
        gm = GameManager.getInstance();
        bool[] sTree =  gm.currData.unlockedPoliciesTreeSick;
        //checks if you have more than the first vaccine policy to increase vaccine increment value
        bool test = sTree[1];
        if(test){
            VaccineSlider.value+=.02f;
        }
        else{
            VaccineSlider.value+=.01f;
        }

        if(VaccineSlider.value>1){
            VaccineSlider.value = 1;
        }
        Progress.text = (int)(VaccineSlider.value * 100f) + "%";
    }

    public void showPolicyMenu() {
        policyMenu.SetActive(true);
        mainGame.SetActive(false);
    }
    public void showMainGame() {
        Debug.Log("Returned to Main Game");
        mainGame.SetActive(true);
        policyMenu.SetActive(false);
        pauseMenu.SetActive(false);
        GameManager.setPause(false);
    }

    public void toMainMenu() {
        Drive.SetCellValue("Unity Data", "J", SavedInfo.userRow.ToString(), DateTime.Now.ToString());
        SceneManager.LoadScene("MainMenu");
    }

    public bool getMainGame()
    {
        return mainGame.activeSelf ? true : false;
    }

    public void toHospitalTree() {
        hospitalTree.SetActive(true);
        restrictionsTree.SetActive(false);
        PSATree.SetActive(false);
        travelTree.SetActive(false);
        sickTree.SetActive(false);
    }

    public void toRestrictionsTree() {
        hospitalTree.SetActive(false);
        restrictionsTree.SetActive(true);
        PSATree.SetActive(false);
        travelTree.SetActive(false);
        sickTree.SetActive(false);
    }

    public void toPSATree() {
        hospitalTree.SetActive(false);
        restrictionsTree.SetActive(false);
        PSATree.SetActive(true);
        travelTree.SetActive(false);
        sickTree.SetActive(false);
    }

    public void toTravelTree()
    {
        hospitalTree.SetActive(false);
        restrictionsTree.SetActive(false);
        PSATree.SetActive(false);
        travelTree.SetActive(true);
        sickTree.SetActive(false);
    }

    public void toSickTree()
    {
        hospitalTree.SetActive(false);
        restrictionsTree.SetActive(false);
        PSATree.SetActive(false);
        travelTree.SetActive(false);
        sickTree.SetActive(true);
    }

}
