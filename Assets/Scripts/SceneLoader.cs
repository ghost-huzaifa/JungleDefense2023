using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public AudioClip menuClip;
    public void loadLevel1()
    {
        //load level 1
        SceneManager.LoadScene("Level 1");
        gameObject.GetComponent<AudioSource>().clip = menuClip;
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void loadLevel2()
    {
        //load level 2
        SceneManager.LoadScene("Level 2");
        gameObject.GetComponent<AudioSource>().clip = menuClip;
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void loadLevel3()
    {
        //load level 3
        SceneManager.LoadScene("Level 3");
        gameObject.GetComponent<AudioSource>().clip = menuClip;
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void loadLevel4()
    {
        //load level 4
        SceneManager.LoadScene("Level 4");
        gameObject.GetComponent<AudioSource>().clip = menuClip;
        gameObject.GetComponent<AudioSource>().Play();
    }
    public void loadLevel5()
    {
        //load level 5
        SceneManager.LoadScene("Level 5");
        gameObject.GetComponent<AudioSource>().clip = menuClip;
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void loadLevelSelect()
    {
        //load Level Select
        SceneManager.LoadScene("Level Select");
        gameObject.GetComponent<AudioSource>().clip = menuClip;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
