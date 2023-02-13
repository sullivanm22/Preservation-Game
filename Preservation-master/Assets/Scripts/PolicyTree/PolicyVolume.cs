using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyVolume : MonoBehaviour
{
    public AudioSource music;
    
    // Start is called before the first frame update
    void Start()
    {
        
        //starts music off at the volume the user previously set
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
