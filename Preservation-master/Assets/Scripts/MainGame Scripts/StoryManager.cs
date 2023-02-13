using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

//Story Questions are displayed every 10 days with the option to choose from 4 answers. The answers have the effects of nothing or to add/subtract money and/or infected people. 
//Story states act as a linked list of other story states
public class StoryManager : MonoBehaviour
{

    private static StoryManager instance;

    [SerializeField] Text storyDescription;
    [SerializeField] Text storyQuestion;

    [SerializeField] Button choiceOne;
    [SerializeField] Text choiceOneText;

    [SerializeField] Button choiceTwo;
    [SerializeField] Text choiceTwoText;

    [SerializeField] Button choiceThree;
    [SerializeField] Text choiceThreeText;

    [SerializeField] Button choiceFour;
    [SerializeField] Text choiceFourText;

    [SerializeField] Image image;

    [SerializeField] StoryState current;

    [SerializeField] Canvas canvas;

    [SerializeField] string consequence;

    Data curr;

    TextManager TM;

    // Start is called before the first frame update
    //Populates data from story state
    void Awake()
    {
        instance = this;
        image.sprite = current.image;
        storyDescription.text = current.description;
        storyQuestion.text = current.question;

        choiceOneText.text = current.choiceOne;
        choiceTwoText.text = current.choiceTwo;
        choiceThreeText.text = current.choiceThree;
        choiceFourText.text = current.choiceFour;


    }

    //Moves to the next state and calls in modifers and consequece text
    void updateState(StoryState nextState, string consequence, string[] modifiers)
    {
        this.current = nextState;
        this.consequence = consequence;
        moneyChange(modifiers[0], modifiers[1]);
        populationChange(modifiers[2], modifiers[3]);

        updateComponents();
        
        
    }

    //When changing story states all components are changed to the next one and then the canvas is hidden until the question is set to appear in 10 days.
    void updateComponents()
    {
        this.image.sprite = current.image;
        this.storyDescription.text = current.description;
        this.storyQuestion.text = current.question;

        this.choiceOneText.text = current.choiceOne;
        this.choiceTwoText.text = current.choiceTwo;
        this.choiceThreeText.text = current.choiceThree;
        this.choiceFourText.text = current.choiceFour;


        hideStory();

        updateAllText();

        //Shows the followup description outcome
        DescriptionWindow.showDescription_static("Outcome", consequence);


    }

    //Cases for when a certain button (1-4) is selected
    public void storySelect(int story)
    {
        switch (story)
        {
            case 1:
                updateState(current.nextChoiceOne, current.choiceOneConsequence, current.choiceOneModifiers);

                break;

            case 2:
                updateState(current.nextChoiceTwo, current.choiceTwoConsequence, current.choiceTwoModifiers);

                break;

            case 3:
                updateState(current.nextChoiceThree, current.choiceThreeConsequence, current.choiceThreeModifiers);

                break;

            case 4:
                updateState(current.nextChoiceFour, current.choiceFourConsequence, current.choiceFourModifiers);

                break;
        }

    }

    public void hideStory()
    {
        canvas.enabled = false;
    }

    public void showStory()
    {
        canvas.enabled = true;
    }

    //Shows Story Canvas and grabs current data
    public static void showStory_static(Data data, TextManager manager)
    {
        instance.curr = data;
        instance.TM = manager;
        instance.showStory();
    }

    //Hides Story Canvas and unpauses game
    public static void hideStory_static()
    {
        GameManager.setPause(false);
        instance.hideStory();
    }
    
    //Modifer for money changes
    public void moneyChange(string sign, string amount)
    {
        int[] price = Formatter.stringToValue(amount);


        if (sign == "-")
        {
            int subMillions = curr.money[0] - price[0];
            if (subMillions < 0)
            {
                curr.money[1]--;
                curr.money[0] = 1000000000 + subMillions;
            }
            else
            {
                curr.money[0] = curr.money[0] - price[0];
            }

            curr.money[1] = curr.money[1] - price[1];

            TM.spawnMoneyPopup("-" + amount);
        }

        else if (sign == "+")
        {
            curr.money = Formatter.addValueArrays(curr.money, price);
            TM.spawnMoneyPopup("+" + amount);
        }

    }
    
    //Modifer for Infection changes
    public void populationChange(string sign, string amount)
    {
        int nInfected = Int32.Parse(amount);

        if (sign == "-")
        {
            curr.infected -= nInfected;
            TM.spawnInfectedPopup("-" + nInfected);
            
            curr.healthy += nInfected;
            TM.spawnHealthyPopup("+" + nInfected);
        }

        else if (sign == "+")
        {
            TM.spawnInfectedPopup("+" + nInfected);
            curr.infected += nInfected;

            curr.healthy -= nInfected;
            TM.spawnHealthyPopup("-" + nInfected);
        }
    }

    //Updates the text
    private void updateAllText()
    {
        TM.setDeathCountText(curr.deaths.ToString());
        TM.setInfectedText(curr.infected.ToString());
        TM.setMoneyText(Formatter.moneyString(curr.money));
        TM.setHealthyText(curr.healthy.ToString());
        }
    }

