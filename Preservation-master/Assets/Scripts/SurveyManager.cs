using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;
using GoogleSheetsForUnity;



public class SurveyManager : MonoBehaviour
{
    //These private vars are used to track the answers, they no longer really need to be global with changes made to code.
    private static float q1ans;
    private static float q2ans;
    private static float q3ans=1;
    private static string q4ans;
    private static string q5ans;
    private static string q6ans;
    private static string q7ans = "Maybe";
    private static string q8ans = "Maybe";
    private static string q9ans;
    private static string q10ans;
    private static float pQ1ans;
    private static string pQ2ans = "Not at all";
    private static string pQ3ans = "Not at all";
    private static string pQ4ans = "Not at all";
    private static string pQ5ans = "Not at all";
    private static string pQ6ans = "Not at all";
    IList<IList<object>> vals = new List<IList<object>>();
    IList<object> list = new List<object>();
    /*initialized here because needs to be used outside of start but was getting errors about imporper calls
     * of using a load function(load is inside GoogleSheetEditor) inside a constructor or in MonoBehaviour. 
     */

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SavedInfo.userRow);
    }
    //All these are for changing the scenes between the survey scenes
   
    
    public void ToSurvey1()
    {
        SceneManager.LoadScene("Survey1");
    }
    public void ToSurvey2() 
    {
        //list here is used as the list inside of a list(vals) to send to GoogleSheetsEditor.postValues
        list.Add("question 1: "+q1ans);
        list.Add("question 2: " + q2ans);
        //vals is the list of lists to send to GoogleSheetEditor.postValues
        
        if (q2ans == 0)
        {
            list.RemoveAt(1);
            vals.Add(list);
            Drive.SetCellValue("Unity Data", "C",SavedInfo.userRow.ToString(), "question 1: " + q1ans.ToString());
            //sheet.postValues("C" + SavedInfo.userRow.ToString() + ":C" + SavedInfo.userRow.ToString(), vals, "C" + SavedInfo.userRow.ToString() + ":C" + SavedInfo.userRow.ToString());
            pQ1ans = q2ans;
            SceneManager.LoadScene("Pre-Survey1");
            
        }
        else
        {
            vals.Add(list);
            Drive.SetCellValue("Unity Data", "AV", SavedInfo.userRow.ToString(), "question 1: " + q1ans.ToString());
            Drive.SetCellValue("Unity Data", "AW", SavedInfo.userRow.ToString(), "question 2: " + q2ans.ToString());
            //sheet.postValues("AV" + SavedInfo.userRow.ToString() + ":AW" + SavedInfo.userRow.ToString(), vals, "AV" + SavedInfo.userRow.ToString() + ":AW" + SavedInfo.userRow.ToString());
            SceneManager.LoadScene("Survey2");
        }
        
        
        
        

    }
    public void ToSurvey3()
    {
        list.Add("question 3: " + q3ans);
        list.Add("question 4: " + q4ans);
        vals.Add(list);
        Drive.SetCellValue("Unity Data", "AX", SavedInfo.userRow.ToString(), "question 3: " + q3ans.ToString());
        Drive.SetCellValue("Unity Data", "AY", SavedInfo.userRow.ToString(), "question 4: " + q4ans.ToString());
        //sheet.postValues("AX" + SavedInfo.userRow.ToString() + ":AY" + SavedInfo.userRow.ToString(), vals, "AX" + SavedInfo.userRow.ToString() + ":AY" + SavedInfo.userRow.ToString());
        SceneManager.LoadScene("Survey3");
    }
    public void ToSurvey4()
    {
        list.Add("question 5: " + q5ans);
        list.Add("question 6: " + q6ans);
        vals.Add(list);
        Drive.SetCellValue("Unity Data", "AZ", SavedInfo.userRow.ToString(), "question 5: " + q5ans.ToString());
        Drive.SetCellValue("Unity Data", "BA", SavedInfo.userRow.ToString(), "question 6: " + q6ans.ToString());
        //sheet.postValues("AZ" + SavedInfo.userRow.ToString() + ":BA" + SavedInfo.userRow.ToString(), vals, "AZ" + SavedInfo.userRow.ToString() + ":BA" + SavedInfo.userRow.ToString());
        SceneManager.LoadScene("Survey4");
    }
    public void ToSurvey5()
    {
        list.Add("question 7: " + q7ans);
        list.Add("question 8: " + q8ans);
        vals.Add(list);
        Drive.SetCellValue("Unity Data", "BB", SavedInfo.userRow.ToString(), "question 7: " + q7ans.ToString());
        Drive.SetCellValue("Unity Data", "BC", SavedInfo.userRow.ToString(), "question 8: " + q8ans.ToString());
        //sheet.postValues("BB" + SavedInfo.userRow.ToString() + ":BC" + SavedInfo.userRow.ToString(), vals, "BB" + SavedInfo.userRow.ToString() + ":BC" + SavedInfo.userRow.ToString());
        SceneManager.LoadScene("Survey5");
    }
    public void BackToSurvey1()
    {
        SceneManager.LoadScene("Survey1");
    }
    public void BackToSurvey2()
    {
        SceneManager.LoadScene("Survey2");
    }
    public void BackToSurvey3()
    {
        SceneManager.LoadScene("Survey3");
    }
    public void BackToSurvey4()
    {
        SceneManager.LoadScene("Survey4");
    }
    public void finish()
    {
        list.Add("question 9: " + q9ans);
        list.Add("question 10: " + q10ans);
        vals.Add(list);
        Drive.SetCellValue("Unity Data", "BD", SavedInfo.userRow.ToString(), "question 9: " + q9ans.ToString());
        Drive.SetCellValue("Unity Data", "BE", SavedInfo.userRow.ToString(), "question 10: " + q10ans.ToString());
        //sheet.postValues("BD" + SavedInfo.userRow.ToString() + ":BE" + SavedInfo.userRow.ToString(), vals, "BD" + SavedInfo.userRow.ToString() + ":BE" + SavedInfo.userRow.ToString());
        Debug.Log("Surevy Complete");
        SceneManager.LoadScene("MainMenu");
    }

    //For Pre-Survey navigation
    public void ToPreSurvey2()
    {
        //list here is used as the list inside of a list(vals) to send to GoogleSheetsEditor.postValues
        list.Add("question 2: " + pQ2ans);
        //vals is the list of lists to send to GoogleSheetEditor.postValues
        vals.Add(list);
        //range here is hardcoded and not what should be final. Probably needs to be handled inside of GoogleSheetEditor
        Drive.SetCellValue("Unity Data", "D", SavedInfo.userRow.ToString(), "question 2: " + pQ2ans.ToString());
        //sheet.postValues("D"+SavedInfo.userRow.ToString() + ":D" + SavedInfo.userRow.ToString(), vals, "D" + SavedInfo.userRow.ToString() + ":D" + SavedInfo.userRow.ToString());
        SceneManager.LoadScene("Pre-Survey2");
    }
    public void ToPreSurvey3()
    {
        list.Add("question 3: " + pQ3ans);
        list.Add("question 4: " + pQ4ans);
        vals.Add(list);
        Drive.SetCellValue("Unity Data", "E", SavedInfo.userRow.ToString(), "question 3: " + pQ3ans.ToString());
        Drive.SetCellValue("Unity Data", "F", SavedInfo.userRow.ToString(), "question 4: " + pQ4ans.ToString());
        //sheet.postValues("E" + SavedInfo.userRow.ToString() + ":F" + SavedInfo.userRow.ToString(), vals, "E" + SavedInfo.userRow.ToString() + ":F" + SavedInfo.userRow.ToString());
        SceneManager.LoadScene("Pre-Survey3");
    }
    public void PreFinish()
    {
        list.Add("question 5: " + pQ5ans);
        list.Add("question 6: " + pQ6ans);
        vals.Add(list);
        Drive.SetCellValue("Unity Data", "G", SavedInfo.userRow.ToString(), "question 5: " + pQ5ans.ToString());
        Drive.SetCellValue("Unity Data", "H", SavedInfo.userRow.ToString(), "question 6: " + pQ6ans.ToString());
        //sheet.postValues("G" + SavedInfo.userRow.ToString() + ":H" + SavedInfo.userRow.ToString(), vals, "G" + SavedInfo.userRow.ToString() + ":H" + SavedInfo.userRow.ToString());
        SceneManager.LoadScene("MainMenu");
    }

    //For going back in the survey
    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void q1Ans()
    {
        q1ans=GameObject.Find("Slider 1").GetComponent<Slider>().value;
        Debug.Log(q1ans);

    }
    public void q2Ans()
    {
        q2ans = GameObject.Find("Slider 2").GetComponent<Slider>().value;
        Debug.Log(q2ans);

    }
    public void q3Ans()
    {
        q3ans = GameObject.Find("1-5 slider").GetComponent<Slider>().value;
        Debug.Log(q3ans);
    }
    public void q4Ans()
    {
        q4ans = GameObject.Find("Q4 Ans").GetComponent<TMPro.TMP_InputField>().text;
        Debug.Log(q4ans);
    }
    public void q5Ans()
    {
        q5ans = GameObject.Find("Q5 Ans").GetComponent<TMPro.TMP_InputField>().text;
        Debug.Log(q5ans);
    }
    public void q6Ans()
    {
        q6ans = GameObject.Find("Q6 Ans").GetComponent<TMPro.TMP_InputField>().text;
        Debug.Log(q6ans);
    }
    public void q7Ans()
    {
        q7ans = GameObject.Find("Q7 Ans").GetComponent<TMPro.TMP_Dropdown>().captionText.text;
        Debug.Log(q7ans);
    }
    public void q8Ans()
    {
        q8ans = GameObject.Find("Q8 Ans").GetComponent<TMPro.TMP_Dropdown>().captionText.text;
        Debug.Log(q8ans);
    }
    public void q9Ans()
    {
        q9ans = GameObject.Find("Q9 Ans").GetComponent<TMPro.TMP_InputField>().text;
        Debug.Log(q9ans);
    }
    public void q10Ans()
    {
        q10ans = GameObject.Find("Q10 Ans").GetComponent<TMPro.TMP_InputField>().text;
        Debug.Log(q10ans);
    }

    /* This is for the pre-survey
     * 
     */
    public void pQ1Ans()
    {
        pQ1ans = GameObject.Find("PQ1Ans").GetComponent<Slider>().value;
        Debug.Log(pQ1ans);
    }
    public void pQ2Ans()
    {
        pQ2ans = GameObject.Find("PQ2Ans").GetComponent<TMPro.TMP_Dropdown>().captionText.text;
        Debug.Log(pQ2ans);
    }
    public void pQ3Ans()
    {
        pQ3ans = GameObject.Find("PQ3Ans").GetComponent<TMPro.TMP_Dropdown>().captionText.text;
        Debug.Log(pQ3ans);
    }
    public void pQ4Ans()
    {
        pQ4ans = GameObject.Find("PQ4Ans").GetComponent<TMPro.TMP_Dropdown>().captionText.text;
        Debug.Log(pQ4ans);
    }
    public void pQ5Ans()
    {
        pQ5ans = GameObject.Find("PQ5Ans").GetComponent<TMPro.TMP_Dropdown>().captionText.text;
        Debug.Log(pQ5ans);
    }
    public void pQ6Ans()
    {
        pQ6ans = GameObject.Find("PQ6Ans").GetComponent<TMPro.TMP_Dropdown>().captionText.text;
        Debug.Log(pQ6ans);
    }
}
