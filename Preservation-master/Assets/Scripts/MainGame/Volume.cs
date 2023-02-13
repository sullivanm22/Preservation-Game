using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Volume : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider volume;

    // Start is called before the first frame update
    void Start()
    {

        //starts game off at the volume the user previously set
        audioSource = GetComponent<AudioSource>();
        volume.value = PlayerPrefs.GetFloat("MusicVolume");

        //SceneManager.LoadScene("MainGame");
        //DontDestroyOnLoad(audioSource);

    }

    // Update is called once per frame
    void Update()
    {

        //adjusts the volume with slider
        audioSource.volume = volume.value;
    }

    //saves volume preferences
    public void VolumePrefs()
    {
        PlayerPrefs.SetFloat("MusicVolume", audioSource.volume);
    }
}
