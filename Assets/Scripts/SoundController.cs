using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{
    public AudioClip[] levelAudio = new AudioClip[6];

    private AudioClip backgroundMusic;
    private void Start()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            case "Level 1":     backgroundMusic = levelAudio[0];        break;
            case "Level 2":     backgroundMusic = levelAudio[1];        break;
            case "Level 3":     backgroundMusic = levelAudio[2];        break;
            case "Level 4":     backgroundMusic = levelAudio[3];        break;
            case "Level 5":     backgroundMusic = levelAudio[4];        break;
            case "Home Screen": backgroundMusic = levelAudio[5];        break;
            case "Level Select":backgroundMusic = levelAudio[5];        break;
        }
        gameObject.GetComponent<AudioSource>().clip = backgroundMusic;
        gameObject.GetComponent<AudioSource>().Play();
    }

}
