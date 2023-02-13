using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public int Population = 1000000;
    public int infected;
    public int ninfected;
    public double deathrate;
    public int TotalDeaths;
    public int DailyDeaths;
    int day;
    float E;
    float P;

    public Text HealthyPop;
    public Text Infected;
    public Text Deaths;
    public Text newinfected;
    public Text Day;
    // Start is called before the first frame update
    void Start()
    {
        infected = 36;
        ninfected = 0;
        deathrate = .003;
        day = 0;
        E = 5;
        P = .9f;

        Debug.Log("population At Start: " + Population);
        Debug.Log("New infected At Start: " + ninfected);
        Debug.Log("Infected At Start: " + infected);
        HealthyPop.text = "" + Population;
        Infected.text = "" + infected;
        Deaths.text = "" + TotalDeaths;
        newinfected.text = "" + ninfected;
        Day.text = "" + day;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Calculate()
    {
        float growth = 1 + (E * P);

        //new infected = E(average number of people who one person can expsoe a day) * P(the probability of each exposure being real)^the day * the number of cases on a given day)  
        Debug.Log("E * P =  " + growth);
        ninfected = ((int)(1 + (E * P)) ^ day) * 36; //exponential one made from simplifying other found equations and also based on the videos and 

        //float _nInfected = Mathf.Pow((float)infected, growth) ; //exponential one made from simplifying other found equations and also based on the videos and
        //ninfected = (int)_nInfected;

        DailyDeaths = (Random.Range(0, (int)(infected * deathrate))); //with deathrate being a bit more volitile this will simulate it well working on getting a new equation 


        Population -= ninfected;


        infected += ninfected;
        infected -= DailyDeaths;


        TotalDeaths += DailyDeaths;
        day++;
    }
    public void UpdateText()
    {

        Debug.Log("population: " + Population);
        Debug.Log("New infected: " + ninfected);
        Debug.Log("Infected: " + infected);

        HealthyPop.text = "" + Population;
        Infected.text = "" + infected;
        Deaths.text = "" + TotalDeaths;
        newinfected.text = "" + ninfected;
        Day.text = "" + day;


    }

    //this will check if certain policies are passed to see if the rate an infected person will infect more people
}
