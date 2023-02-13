using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//These elements connects the story state to the UI elements to create scriptable objects
//Story states act as a linked list of other story states
[CreateAssetMenu(menuName = "Story State")]
public class StoryState : ScriptableObject
{
    [TextArea(5, 10)] [SerializeField] public string description;
    [TextArea(5, 10)] [SerializeField] public string question;

    [TextArea(5, 10)] [SerializeField] public string choiceOne;
    [TextArea(5, 10)] [SerializeField] public string choiceOneConsequence;
    [SerializeField] public string[] choiceOneModifiers;
    [TextArea(5, 10)] [SerializeField] public string choiceTwo;
    [TextArea(5, 10)] [SerializeField] public string choiceTwoConsequence;
    [SerializeField] public string[] choiceTwoModifiers;
    [TextArea(5, 10)] [SerializeField] public string choiceThree;
    [TextArea(5, 10)] [SerializeField] public string choiceThreeConsequence;
    [SerializeField] public string[] choiceThreeModifiers;
    [TextArea(5, 10)] [SerializeField] public string choiceFour;
    [TextArea(5, 10)] [SerializeField] public string choiceFourConsequence;
    [SerializeField] public string[] choiceFourModifiers;

    [SerializeField] public StoryState nextChoiceOne;
    [SerializeField] public StoryState nextChoiceTwo;
    [SerializeField] public StoryState nextChoiceThree;
    [SerializeField] public StoryState nextChoiceFour;

    [SerializeField] public Sprite image;
}
