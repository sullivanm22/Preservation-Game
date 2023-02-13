using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public AudioSource music;

    //starts game off at the volume the user previously set
    void Start()
    {
        music.volume = PlayerPrefs.GetFloat("MusicVolume");

        DontDestroyOnLoad(music);
    }

    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void QuitGame () 
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
