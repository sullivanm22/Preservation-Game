using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script handles the random events that take place at the start of a new day and will randomly trigger. These will only happen after the 7th day.
 *The event will happen if a certain policy is NOT bought yet. Buying a certain policy will prevent the event from happening in the future.
 *These events either have the effects of death or small, medium, or large infection rate. The numbers are multipler modifers that are added to the formula script to generate the amount of infection/deaths.
 *For more information on the requirments for each event happening, refer to Random Events Doc in the Preservation One Drive Folder
 */
public class RandomEvents : MonoBehaviour
{

    public static RandomEvents instance;

    public static EventManager em = new EventManager();

    private List<int> eventIndex = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 };



    public static (int, int) eventModifier()  //(infected, deaths) modifers
    {
        //Makes sure we are not in tutorial mode and that the game day is over 7.
        if (!DescriptionWindow.tutorialMode() && GameManager.getDay() > 7)
        {


            Shuffle(instance.eventIndex);

            //Random numbers generated for a random amount of infected 
            int smallRandomNumber = Random.Range(1, 10);
            int mediumRandomNumber = Random.Range(11, 20);
            int largeRandomNumber = Random.Range(21, 35);


            //When an event is chosen, it passes through here where it pauses the game and then the effects will take place as well as the description details. 
            for (int i = 0; i < 8; i++)
            {
                switch (instance.eventIndex[i])
                {
                    case 0:
                        if (instance.fullHospital()) //Death Event
                        {
                            Debug.Log("Full Hospital Event ");
                            GameManager.setPause(true);
                            string descriptionText = "There are not enough hospitals for all the infected people! 2 percent of the infected population has died overnight. This will continue to happen unless you establish more field hospitals!"; //Event description
                            DescriptionWindow.showDescription_static("All the hospitals are full!", descriptionText); //"" is the Title of the event
                            return (0, 2);
                        }
                        break;

                    case 1:
                        if (instance.moreVentilators()) //Death Event
                        {
                            Debug.Log("More Ventilators Event ");
                            GameManager.setPause(true);
                            string descriptionText = "There are not enough ventilators for the population at risk, leaving people vulnerable without them.  This left 10 percent of infected population without the critical care they needed, causing them to pass away. This may happen again, it is best to buy more ventilators to make sure you have enough for your country.";
                            DescriptionWindow.showDescription_static("There are not enough ventilators", descriptionText);
                            return (0, 10);
                        }
                        break;

                        //The rest of the events only effect Infection
                    case 2:
                        if (instance.smallInfectedGathering())
                        {
                            Debug.Log("Small Infected Gathering Event ");
                            GameManager.setPause(true);
                            string descriptionText = "People have been reported to be going to birthday parties and clubs during the weekend. The indoor spaces cause the infection to spread easily, resulting in a " + smallRandomNumber.ToString() + " percent extra of the population testing positive since the weekend. Limit indoor gatherings to prevent this from happening again.";
                            DescriptionWindow.showDescription_static("More people infected over the weekend!", descriptionText);
                            return (smallRandomNumber, 0);
                        }
                        break;

                    case 3:
                        if (instance.mediumInfectedGathering())
                        {
                            Debug.Log("Medium Infected Gathering Event ");
                            GameManager.setPause(true);
                            string descriptionText = "After a large gathering took place yesterday, a report of " + mediumRandomNumber.ToString() + " percent of the population have been tested positive for having COVID19. Large gatherings will continue to cause more infection if you do no ban them soon.";
                            DescriptionWindow.showDescription_static("People infected during concert", descriptionText);
                            return (mediumRandomNumber, 0);
                        }
                        break;

                    case 4:
                        if (instance.largeInfectedGathering())
                        {
                            Debug.Log("Large Infected Gathering Event");
                            GameManager.setPause(true);
                            string descriptionText = "Due to the holiday season, people are going out more and gathering with family and friends. This resulted in entire families contracting the coronavirus and a " + largeRandomNumber.ToString() + " percent increase in more positive COVID cases. Your previous limits on indoor gathering seem to not be enough.";
                            DescriptionWindow.showDescription_static("Spike in COVID during the holiday", descriptionText);
                            return (largeRandomNumber, 0);
                        }
                        break;

                    case 5:
                        if (instance.allPSA())
                        {
                            Debug.Log("All PSA Event ");
                            GameManager.setPause(true);
                            string descriptionText = "COVID19 is very new to everyone in the world. Many are scared and confused about it since there is a lot of misinformation or no information at all. By FULLY informing the public about COVID they will be better prepared for defending themselves against the infection. There are " + smallRandomNumber.ToString() + " percent increase in postive COVID cases.";
                            DescriptionWindow.showDescription_static("The public does not have enough information!", descriptionText);
                            return (smallRandomNumber, 0);
                        }
                        break;

                    case 6:
                        if (instance.infectedTravler())
                        {
                            Debug.Log("Infected Travler Event");
                            GameManager.setPause(true);
                            string descriptionText = "While there is a limit for international travelers, some people returning are not quarantined after their trip and spreading infection. This problem was connected to a " + mediumRandomNumber.ToString() + " percent increase in positive COVID cases. To prevent this from happening, you must have a mandatory quarantine for international travelers.";
                            DescriptionWindow.showDescription_static("Travelers have brought infection", descriptionText);
                            return (mediumRandomNumber, 0);
                        }
                        break;

                    case 7:
                        if (instance.infectedQuarantine())
                        {
                            Debug.Log("Infected Quarentine Event ");
                            GameManager.setPause(true);
                            string descriptionText = "After contracting the coronavirus, some people aren't listening to the CDC’s recommendation to quarantine for a full 14 day period. They are going out early while they are still contagious resulting in " + largeRandomNumber.ToString() + " percent of extra positive COVID cases.";
                            DescriptionWindow.showDescription_static("People aren't quarantining", descriptionText);
                            return (largeRandomNumber, 0);
                        }
                        break;

                }
            }
        }
        return (0,0);
    }

    //This makes the list random so that the same events will not be chosen in order. This way at the start of each day the event list is went through randomly.
    public static void Shuffle(List<int> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    //These methods handle if the event will actually happen. A random number is established and then compared to what the chance of the event is. These only handle if the event will happen or not, the effects are handled above. 
    //The chances of each event happening are seemingly small to prevent an event from happeing daily. 
    private bool fullHospital()
    {
        if (!em.isPassedPolicy(1, 2)) //1 is the Hospital tree, 2 is policy to Establish Field III Hospital
        {
            int randomNumber = Random.Range(0, 100);

            //Chance of event happening: 5
            if (randomNumber <= 5)
            {
                return true;
            }
        }
        return false;
    }

    private bool moreVentilators()
    {
        if (!em.isPassedPolicy(1, 3)) //1 is the hospital tree, 3 is policy to Buy more Ventilators
        {
            int randomNumber = Random.Range(0, 100);

            if (randomNumber <= 3)
            {
                return true;
            }
        }
        return false;
    }

    //Event that is based on whether the Large Gatherings is banned
    private bool smallInfectedGathering()
    {
        if (!em.isPassedPolicy(2, 1)) //2 is the restriction tree, 1 is policy to BAN large gatherings
        {
            int randomNumber = Random.Range(0, 100);

            if(randomNumber <= 18)
            {
                return true;
            }
        }
        return false;
    }

    private bool mediumInfectedGathering()
    {
        if (!em.isPassedPolicy(2, 2)) //2 is the restriction tree, 2 is Limit Indoor Gatherings
        {
            int randomNumber = Random.Range(0, 100);

            if (randomNumber <= 12)
            {
                return true;
            }
        }
        return false;
    }

    private bool largeInfectedGathering()
    {
        if (!em.isPassedPolicy(2, 4)) //2 is the restriction tree, 4 is Futher Limit Indoor Gatherings
        {
            int randomNumber = Random.Range(0, 100);

            if (randomNumber <= 4)
            {
                return true;
            }
        }
        return false;
    }

    private bool allPSA()
    {
        if (!(em.isPassedPolicy(3, 0) && em.isPassedPolicy(3, 1) && em.isPassedPolicy(3, 2) && em.isPassedPolicy(3, 3) && em.isPassedPolicy(3, 4))) //4 is the PSA tree, 0-4 is ALL non-negative PSA Policies
        {
            int randomNumber = Random.Range(0, 100);

            if (randomNumber <= 1)
            {
                return true;
            }
        }
        return false;
    }

    private bool infectedTravler()
    {
        if (!em.isPassedPolicy(4, 3)) //4 is the travel tree, 3 is policy to Mandatory Quarentine for Internation Travel Restrictions
        {
            int randomNumber = Random.Range(0, 100);

            if (randomNumber <= 3)
            {
                return true;
            }
        }
        return false;
    }

    private bool infectedQuarantine()
    {
        if (!em.isPassedPolicy(5, 8)) //5 is the sick tree, 8 is policy to Mandatory 14 Day Quarantine
        {
            int randomNumber = Random.Range(0, 100);

            if (randomNumber <= 9)
            {
                return true;
            }
        }
        return false;
    }


}
