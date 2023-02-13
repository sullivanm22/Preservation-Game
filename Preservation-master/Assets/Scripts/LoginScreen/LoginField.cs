using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System;
using GoogleSheetsForUnity;
using System.Text.RegularExpressions;

public class LoginField: MonoBehaviour
{
    //Used purely to be able to easily parse response from drive
    public struct tablefields
    {
       public string user_id,username,Preq1, Preq2, Preq3, Preq4, Preq5, Preq6, game_start_time, game_end_time, Establish_Field_Hospital_1_Buy_Time, Establish_Field_Hospital_2_Buy_Time, Establish_Field_Hospital_3_Buy_Time, Buy_More_Ventilators_1_Buy_Time, Expand_ICU_Capacity_1_Buy_Time, Limit_Large_Gatherings_Buy_Time, Ban_Large_Gatherings_Buy_Time, Limit_Indoor_Gatherings_Buy_Time, Limit_Outdoor_Gatherings_Buy_Time, Further_Limit_Indoor_Gatherings_Buy_Time, Weekly_Updates_To_Public_Buy_Time, Start_Daily_Updates_Buy_Time, Create_Covid_Infographics_Buy_Time, Have_Experts_Speak_Publicly_Buy_Time, Create_Website_For_Public_Buy_Time, Misinform_The_Public_Buy_Time, Lie_About_Numbers_Buy_Time, Further_Lie_Buy_Time, Denounce_Experts_Buy_Time, Travel_Quarantine_Buy_Time, State_Quarantine_Buy_Time, Close_Land_Border_Buy_Time, Close_Airports_Buy_Time, Close_Borders_Buy_Time, Close_Water_Borders_Buy_Time, Impose_International_Travel_Restrictions_Buy_Time, Impose_Interstate_Travel_Restrictions_buy_Time, Vaccine_Funding_Buy_Time, Increase_Funding_1_Buy_Time, Give_Special_Permissions_Buy_Time, Increase_Funding_2_Buy_Time, Allow_Human_Trials_Buy_Time, Give_FDA_Approval_Buy_Time, Develop_A_Vaccine_Buy_Time, Mandatory_Quarantine_7_Days_Buy_Time, Manditory_Quarantine_14_Days_Buy_Time, Contact_Tracing_Buy_Time, Post_q1, Post_q2, Post_q3, Post_q4, Post_q5, Post_q6, Post_q7, Post_q8, Post_q9, Post_q10;
    }
    public struct loginInfo
    {
        public string userid;
        public string username;
    }
    loginInfo _login = new loginInfo();
    private string _table = "Unity Data";
    private string userId;
    public int userRow;
    private string pass="WITGames";
    public Button playButton;
    private GameObject usernameInput;
    public string user; //Access this by using LoginField.user in other scripts/objects, should work but might need to be tested
    GameObject wrongPass; //text object for incorrect password



    // All these methods are based on the SpreadsheetsExample file
    private void OnEnable()
    {
        // Suscribe for catching cloud responses.
        Drive.responseCallback += HandleDriveResponse;
    }

    private void OnDisable()
    {
        // Remove listeners.
        Drive.responseCallback -= HandleDriveResponse;
    }
    public void HandleDriveResponse(Drive.DataContainer dataContainer)
    {
        Debug.Log(dataContainer.msg);
        
        // First check the type of answer.
        if (dataContainer.QueryType == Drive.QueryType.getObjectsByField)
        {
            string rawJSon = dataContainer.payload;
            Debug.Log(rawJSon);

            // Check if the type is correct.
            if (string.Compare(dataContainer.objType, _table) == 0)
            { 

            }
        }
        if (dataContainer.QueryType == Drive.QueryType.getTable)
        {
            string rawJSon = dataContainer.payload;
            Debug.Log(rawJSon);

            // Check if the type is correct.
            if (string.Compare(dataContainer.objType, _table) == 0)
            {
                // Parse from json to the desired object type.
                //tablefields[] table = JsonHelper.ArrayFromJson<tablefields>(rawJSon);
                //Debug.Log(table);
                
                userRow = Regex.Matches(rawJSon,"user_id").Count+2;
                Debug.Log(userRow);
                SavedInfo.userRow = userRow;
                //Debug.Log(table.Length);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Finds the play button and sets up a listener to see when it is clicked
        GameObject playbtn = GameObject.Find("Play Button");
        Button play = playbtn.GetComponent<Button>();
        play.onClick.AddListener(VerifyPasswd);

        //Finds then disables the error text for entering the wrong password
        wrongPass = GameObject.Find("WrongPasswordText");
        wrongPass.SetActive(false);

        //Finding username objectg and using to save password
        usernameInput = GameObject.Find("Username Input");
        
        _login.userid=AnalyticsSessionInfo.userId;
        Debug.Log(_login.userid);
        FindUserCol();
        
        

    }
    //Used for Analytics to google sheet
    private void FindUserCol()
    {
        
        Debug.Log("FindUserCol started");
        Drive.GetTable(_table, true);
        //Drive.GetObjectsByField(_table, "user_id", "1");
        
    }


    public void VerifyPasswd()
    {
        //Finds the text input object
        GameObject passField = GameObject.Find("Password Input");
        user = usernameInput.GetComponent<InputField>().text;
        GameObject userField = GameObject.Find("Username Input");
        //Only set up to do anything if password is correct when button is clicked
        if (passField.GetComponent<InputField>().text == pass)
        {
            //Build is set to have login=0 mainMenu=1 mainGame=2
            //Set to load the main menu scene if password is correct
            _login.username = userField.GetComponent<InputField>().text;
            SavedInfo.username = user;
            Drive.SetCellValue(_table, "A", userRow.ToString(), _login.userid);
            Drive.SetCellValue(_table, "B", userRow.ToString(), user);
            Drive.responseCallback -= HandleDriveResponse;
            Debug.Log("Correct Password Entered.");
            
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            //Sets the wrongPass to active which is the text object
            var attemptedPass = new Dictionary<string, object>();
            attemptedPass["PasswordAttempt"] = passField.GetComponent<InputField>().text;
            wrongPass.SetActive(true);
        }
    }

}
