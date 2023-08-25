using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//This GameController handles all the UI work
public class Controller : MonoBehaviour
{
    private int score = 0;
    private int currentLevel = 1;

    public bool isGameStarted = false;
    public int earnedStars = 3;
    public GameObject gameOverScreenObj;
    public GameObject victoryScreenObj;
    public GameObject victoryScreenScoreObj;
    public GameObject uiScoreObj;
    public GameObject pauseScreenObj;


    private void Start()
    {
        //Keep all the UIs disabled at the start
        gameOverScreenObj.SetActive(false);
        victoryScreenObj.SetActive(false);
        pauseScreenObj.SetActive(false);

        //Get Current Level
        currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
    }

    private void Update()
    {
        //set the score UI
        uiScoreObj.GetComponent<TextMeshProUGUI>().text = score.ToString();

        //Check if the game is won
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        if (enemies.Length == 0 && isGameStarted)
        {
            victory();
        }
    }



    //Game Over and Victory Button Functions
    public void restartLevel()
    {
        SceneManager.LoadScene("Level " + currentLevel);
    }
    public void returnToLevelSelect()
    {
        SceneManager.LoadScene("Level Select");
    }
    public void nextLevel()
    {
        if (currentLevel == 5)
            SceneManager.LoadScene("Level Select");
        else
            SceneManager.LoadScene("Level " + (currentLevel + 1));
    }




    //Player Score Manipulation Functions
    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }



    //Victory Functions
    public void victory()
    {
        victoryScreenObj.SetActive(true);
        switch (earnedStars)
        {
            case 3:
                GameObject.Find("1Star").SetActive(true);
                GameObject.Find("2Star").SetActive(true);
                GameObject.Find("3Star").SetActive(true);
                break;
            case 2:
                GameObject.Find("1Star").SetActive(true);
                GameObject.Find("2Star").SetActive(true);
                GameObject.Find("2Star").SetActive(false);
                break;
            case 1:
                GameObject.Find("1Star").SetActive(true);
                GameObject.Find("2Star").SetActive(false);
                GameObject.Find("2Star").SetActive(false);
                break;
            default:
                break;
        }
        victoryScreenScoreObj.GetComponent<TextMeshProUGUI>().text = score.ToString();
        setShoot(false);
        setPowerups(false);
    }


    //Game Over Functions
    public void gameOver()
    {
        gameOverScreenObj.SetActive(true);
        setEnemiesMovement(false);
        setEnemiesSpawning(false);
        setShoot(false);
        setPowerups(false);
    }


    //Pause Menu Function
    public void pauseGame()
    {
        pauseScreenObj.SetActive(true);
        setEnemiesMovement(false);
        setEnemiesSpawning(false);
        setShoot(false);
        setPowerups(false);
    }

    //Resume Button Function
    public void resumeGame()
    {
        pauseScreenObj.SetActive(false);
        setEnemiesMovement(true);
        setEnemiesSpawning(true);
        setShoot(true);
        setPowerups(true);
    }



    //sub-functions, which stops all processes
    private void setEnemiesMovement( bool value)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMechanics>().isGameOver = !value;
        }
    }

    private void setEnemiesSpawning(bool value)
    {
        GameObject spawner = GameObject.FindGameObjectWithTag("spawner");
        spawner.GetComponent<EnemySpawner>().enabled = value;
    }

    private void setShoot(bool value)
    {
        GameObject castle = GameObject.FindGameObjectWithTag("castle");
        castle.GetComponent<Shoot>().enabled = value;
    }

    private void setPowerups(bool value)
    {
        GameObject powerups = GameObject.FindGameObjectWithTag("powerups");
        powerups.GetComponent<Powerups>().isGameOver = !value;
    }

}
