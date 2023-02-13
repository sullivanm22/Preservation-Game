using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSound : MonoBehaviour
{

    public AudioSource source;
    public AudioClip hover;
    public AudioClip click;

    public void loadNextScene()
    {
        StartCoroutine(LoadingLevel());
    }

    IEnumerator LoadingLevel()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("MainGame");
    }

    public void Onhover()
    {
        source.PlayOneShot(hover);
    }

    public void Onclick()
    {
        source.PlayOneShot(click);
    }

}
