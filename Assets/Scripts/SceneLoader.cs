using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadLevel1()
    {
        //load level 1
        SceneManager.LoadScene("Level 1");
    }
}
