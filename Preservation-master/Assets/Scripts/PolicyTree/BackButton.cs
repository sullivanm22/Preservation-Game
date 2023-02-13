using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    
    //from policy tree, if you press the back button, it goes back to the main game
    public void BackToMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
