using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using GoogleSheetsForUnity;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;

    public Data currData;
    public AudioManager AM;
    public TextManager TM;
    public MenusManager MM;
    public PauseMenuManager PMM;
    public PolicyManager PM;
    public StoryManager SM;


    private float delayFrames;
    private float delayTime;
    public float defaultDelayTime;
    private float nextActionTime = 0;
    public bool paused = false;
    private bool storyRun = false;
    private int nextEventNum = -4;
    private bool gameLost = false;
    private int policyVariable = 0;
    private int initialPop;
    //Allow for custom start.
    public static bool customReset;
    public string defaultMoney;
    public int defaultHealthy;
    public int defaultInfected;
    public int defaultDeaths;
    public int defaultDay;
    public int defaultPP;
    public int defaultHappiness;
    public int defaultDDay; //Day that infected starts.
    

    //Serialized variable allows for value editing within Unity Inspector.
    [SerializeField]
    private int frameRate;

    [SerializeField]
    private int[] regularTaxEarnings;

    public static GameManager getInstance() {
        return instance;
    }

    public void gameOver() {
        SaveManager.saveDelete_Static();
    }

    //calculates the frames needed to get the requested delay time (seconds).
    public void calculateDelayFrames() {
        delayFrames = delayTime * frameRate;
    }

    //Speeds up update time.
    public void fastForward() {
        delayTime = defaultDelayTime/6f;
        calculateDelayFrames();
        
    }

    //Returns the upate time to regular speed.
    public void regularSpeed() {
        delayTime = defaultDelayTime;
        calculateDelayFrames();
    }
        
    //Brings up pause menu.
    public void pause()
    {
        paused = true;
        MM.showPauseMenu();
    }

    public static void setPause(bool b)
    {
        instance.paused = b;
    }

    public static void hideDesc()
    {
        Debug.Log("button push");
        DescriptionWindow.hideDesc_Static();
        setPause(false);

    }

    //Shows main game screen.
    public void returnToGame() {
        paused = false;
        MM.showMainGame();
        //if(checkForVaccinePolicy())
        //{
        //    MM.showSlider();
        //}
        
    }

    //Shows policy menu.
    public void showPolicies() {
        paused = true;
        MM.showPolicyMenu();
    }

    public (bool[], bool[], bool[], bool[], bool[]) getPassedPolicies()
    {
        
        return (currData.unlockedPoliciesTreeHospital,
            currData.unlockedPoliciesTreeRestrictions,
            currData.unlockedPoliciesTreePSA,
            currData.unlockedPoliciesTreeTravel,
            currData.unlockedPoliciesTreeSick);
    }


    //Opens vaccine tree data, checks if certain policy is bought before showing vaccine progress bar(intended as win condition)
    //Changed to always show vaccine slider to help players understand the goal
    public bool checkForVaccinePolicy()
    {
        Debug.Log("Checking for vaccine policy");
        bool[] sTree = currData.unlockedPoliciesTreeSick;
        bool test = sTree[0];
        return test;
    }

    

    /// <summary>
    /// Returns all values to their defaults state.
    /// also updates UI with default Values.
    /// </summary>
    private void restart()
    {
        //if (customReset)
        //else
        //    {
        //    Debug.Log("Ran restart");
        //    currData.reset();
        //    }

        currData.setNewValues(currData.money, defaultHappiness, currData.PP, currData.healthy, defaultInfected, defaultDeaths, defaultDay, DifficultyMenu.getDDayInfo());
        
        
        nextActionTime = 0;
        delayTime = defaultDelayTime;
        calculateDelayFrames();

        updateAllText();
        SaveManager.save_Static();
    }

    //Updates all in game text boxes with current game values.
    private void updateAllText() {
        TM.setDayValText(currData.day.ToString());
        TM.setDeathCountText(currData.deaths.ToString());
        TM.setHappinessText(currData.happiness.ToString() + "%");
        TM.setInfectedText(currData.infected.ToString());
        TM.setMoneyText(Formatter.moneyString(currData.money));
        TM.setHealthyText(currData.healthy.ToString());
        TM.setPPText(currData.PP.ToString());
        TM.setPolicyMoneyText(Formatter.moneyString(currData.money));
        TM.setPolicyPPText(currData.PP.ToString());
        
        
    }

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }

        StoryManager.hideStory_static();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = frameRate;
        SaveManager.load_Static(PlayerPrefs.GetString("Save"));
        nextActionTime = 0;
        delayTime = defaultDelayTime;
        initialPop = currData.healthy;
        calculateDelayFrames();
        updateAllText();
        Drive.SetCellValue("Unity Data", "I", SavedInfo.userRow.ToString(), DateTime.Now.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        //Lets player press escape to pause game.
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            DescriptionWindow.hideDesc_Static();
            if (!paused)
            {
                pause();
            }
            else
            {
                //Returns player to main pause menu if pressing escape in options menu.
                //Otherwise return to game.
                if (!PMM.optionsOpen)
                {
                    returnToGame();
                }
                else {
                    PMM.back();
                }
            }
        }

        if(!paused && currData.day == 1 && nextEventNum < 0)
        {
            Debug.Log($"Running tutorial {nextEventNum}");
            setPause(true);
            updateAllText();
            DescriptionWindow.showTutorial_static(nextEventNum++);
        }

        //Checks that the game is playing, a story hasnt been run in the previous fram, that is over day 6, and that every 10th day it will play the next story. 
        if (!paused && currData.day > 6 && currData.day % 10 == 0 && !storyRun)
        {
            Debug.Log($"Running story");
            setPause(true);
            storyRun = true;
            updateAllText();
            StoryManager.showStory_static(currData, TM);
        }

        //Lets player press P to access policy menu;
        if (Input.GetKeyDown(KeyCode.P) && !paused)
        {
            showPolicies();
        }
        else if(Input.GetKeyDown(KeyCode.P) && paused)
        {
            returnToGame();
        }
        //Only updates game time if game isn't paused.
        if (!paused) {
            nextActionTime += 1;
        }

        //When delay time is reached, Updates information for next day.
        if (!paused && nextActionTime >= delayFrames)
        {
            
            nextActionTime = 0;
            currData.day += 1;
            if(checkForVaccinePolicy()){
                MM.updateSlider();
            }
            calculateNextDay();
            storyRun = false;
}

        if(currData.healthy <= 0 && currData.infected == 0)
        {
            setPause(true);
            DescriptionWindow.loseScreen_static();
            gameLost = true;
        }
        if(gameLost)
        {
                if(DescriptionWindow.getLose_static())
                reloadMainMenu();
        }
    }
    
    private void reloadMainMenu()
    {
        Drive.SetCellValue("Unity Data", "J", SavedInfo.userRow.ToString(), DateTime.Now.ToString());
        SceneManager.LoadScene("MainMenu");
    }

    //Calculates all numbers needed for updating information for the next day.
    public void calculateNextDay() {
        calculateMoney();
        //this is used to stop people from getting infected before Dday
        if(currData.day > currData.dDay){
            calculatePopulation();
        }
        calculatePolicyPoints();
        calculateHappiness();
        updateAllText();
    }

    //Calculates both earnings and expenses for money for the next day.
    private void calculateMoney() {
        calculateEarnings();
        updateAllText();
    }

    //Calculates income for next day
    private void calculateEarnings() {
        int[] additiveMoney = { 0, 0 };
        int[] taxes = calculateTaxes();
        additiveMoney = Formatter.addValueArrays(additiveMoney, taxes);

        if (additiveMoney[0] > 0 || additiveMoney[1] > 0) {
            TM.spawnMoneyPopup("+" + Formatter.moneyString(additiveMoney));
        }
        currData.money = Formatter.addValueArrays(currData.money, additiveMoney);
    }

    public void spendMoney(Policy passed)
    {
        int[] price = passed.getMoney();
        int subMillions = currData.money[0] - price[0];
        if(subMillions < 0)
        {
            currData.money[1] --;
            currData.money[0] = 1000000000 + subMillions;
        }
        else
        {
            currData.money[0] = currData.money[0] - price[0];
        }

        currData.money[1] = currData.money[1] - price[1];
        Debug.Log("Just spent some money");
        updateAllText(); // Have a separate method for updating money perhaps?

    }
    //Getter for analytics
    public int getInfected()
    {
        return currData.infected;
    }
    public int getHealthy()
    {
        return currData.healthy;
    }
    public int getHappy()
    {
        return currData.happiness;
    }
    public int getPolicyP()
    {
        return currData.PP;
    }
    //Calculates how many newly infected people there are and how many died.
    //S. I. R.
    private void calculatePopulation() {

        if (currData.healthy == 0 && currData.infected == 0) {
            Formulas.refreshDeathQueue();
            return;
        }
        if (currData.day == currData.dDay) {
            currData.healthy -= 1;
            TM.spawnHealthyPopup("-1");
            currData.infected = 1;
        }

        int nInfected = Formulas.CalculateNewInfected(currData);
        Debug.Log("New number of infected" + nInfected);


        //Infected population
        if(currData.infected + nInfected >= currData.healthy) // here it possibly goes overboard, so this smooth's out the numbers (really only used to make the infected population make sense at a losing screen)
        {
            TM.spawnInfectedPopup("+" + currData.healthy);
            currData.infected += currData.healthy;
        }
        else if(nInfected > 0)
        {
            TM.spawnInfectedPopup("+" + nInfected);
            currData.infected += nInfected;
        }
        else if(nInfected < 0)    // here nInfected < 0
        {
            TM.spawnInfectedPopup("-" + nInfected);
            currData.infected += nInfected;  
        }
        else
        {

        }


        //Healthy population
        if(currData.healthy - nInfected < 0)
        {
            TM.spawnHealthyPopup("-" + currData.healthy);
            currData.healthy = 0;
        }
        else if (nInfected > 0 && currData.day - currData.dDay > 1)
        {
            currData.healthy -= nInfected;
            TM.spawnHealthyPopup("-" + nInfected);
        }
        else if (nInfected < 0 && currData.day - currData.dDay > 1)
        {
            currData.healthy -= nInfected; //double negative. - - is a +
            TM.spawnHealthyPopup("+" + nInfected);
        }

        
        StartCoroutine(delayForDeaths(nInfected));
        updateAllText();
    }


   public static int getDay()
    {
        return instance.currData.day;
    }

    private IEnumerator delayForDeaths(int nInfected)
    {
        (int nDeaths, int survivors)= Formulas.CalculateNewDeaths(nInfected, currData);
        yield return new WaitForSeconds((float) delayTime / 2);
        if(survivors > 0)
        {
            TM.spawnHealthyPopup("+" + survivors + " recovered!");
            currData.healthy += survivors;    
        }

        if(nDeaths > 0)
        {
            TM.spawnDeathPopup("+" + nDeaths);
            currData.deaths += nDeaths;
        }

        int deathsAndSurvivors = nDeaths + survivors;
        if(currData.infected - deathsAndSurvivors < 0)
        {
            TM.spawnInfectedPopup("-" + currData.infected);
            currData.infected = 0;
        }
        else if(deathsAndSurvivors > 0)
        {
            TM.spawnInfectedPopup("-" +  deathsAndSurvivors);
            currData.infected -= deathsAndSurvivors;
        }
       updateAllText();
    }

    //calculates how many policy points the player gets on the next day.
    private void calculatePolicyPoints() {

        if(policyVariable % 3 == 0)
        {
            currData.PP++;
        }
        policyVariable++;

    }

    //Calculates the happiness of your population for the next day.
    private void calculateHappiness() {
        //if num infected is greater than 25% of pop -1 from happiness
        double percentInfected = currData.infected/initialPop;
        if(currData.happiness>0){
            if(percentInfected>=.25){
                currData.happiness -=1;
            }
        }        
        updateAllText();

    }

    //Calculates how much money the player gains from taxes from the population that day.
    private int[] calculateTaxes() {
        int[] taxes = regularTaxEarnings;
        return taxes;
    }

}

       /* OLD calculatePop() stuff throw away but saving incase it has something good IDK 
        if(nInfected > 0)
            TM.spawnInfectedPopup("+" + nInfected);
        else
        {
            TM.spawnInfectedPopup("-" + nInfected);
        }
        currData.deaths += nDeaths;
        if(nDeaths > 0)
            TM.spawnInfectedPopup("+" +  nInfected);
        

        
        if (nDeaths > 0)
        {
            currData.deaths += nDeaths;
            TM.spawnDeathPopup("+" + nDeaths);// only goes up
        }
        */


/*      
        //int changeInfected = nInfected - nDeaths;

        if(nInfected > 0)
        {
            if (nInfected > currData.healthy)
            {
                if (currData.healthy > 0)
                {
                    TM.spawnHealthyPopup("-" + currData.healthy);
                    nInfected = currData.healthy;
                    currData.healthy = 0;
                }
                else {
                    nInfected = 0;
                }
                changeInfected = nInfected - nDeaths;
            }
            else
            {
                currData.healthy -= nInfected;
                TM.spawnHealthyPopup("-" + nInfected);
            }
            
        }

        if (changeInfected > 0) {
            currData.infected += changeInfected;
            TM.spawnInfectedPopup("+" + changeInfected);
        } else if (changeInfected < 0) {
            if (changeInfected * (-1) > currData.infected)
            {
                TM.spawnInfectedPopup("-" + currData.infected);
                nDeaths = currData.infected;
                currData.infected = 0;
            }
            else
            {
                currData.infected += changeInfected;
                TM.spawnInfectedPopup(changeInfected.ToString());
            }
        }
*/
