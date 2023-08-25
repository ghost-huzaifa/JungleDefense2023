using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject mushroom, bush, trashcan, pinecord, cat;
    public float Enemy_spawn_rate = 1;

    private GameObject enemy, controller;
    private bool allEnemiesSpawned = false;
    private float tempTime, attackRate, Ellipse_a = 7.5f, Ellipse_b = 4f;
    private int sign = -1, enemyCount = 0, enemyCountLimit;
    private string currentLevel;
    private Vector3 spawnLocation = Vector3.zero;

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        switch(SceneManager.GetActiveScene().name)
        {
            case "Level 1":     currentLevel = "Level 1";   enemyCountLimit = 30;   break;
            case "Level 2":     currentLevel = "Level 2";   enemyCountLimit = 40;   break;
            case "Level 3":     currentLevel = "Level 3";   enemyCountLimit = 50;   break;
            case "Level 4":     currentLevel = "Level 4";   enemyCountLimit = 60;   break;
            case "Level 5":     currentLevel = "Level 5";   enemyCountLimit = 70;   break;
            default:            currentLevel = "Level1";    enemyCountLimit = 30;   break;
        }

        tempTime = 0f;
        enemyCount = 0;
    }


    void Update()
    {
        //Check Count of Enemies and end level accordingly
        if (enemyCount > enemyCountLimit)
            allEnemiesSpawned = true;
        
        //Spawn enemies according to the level
        if (tempTime > (1/Enemy_spawn_rate) && !allEnemiesSpawned)
        {
            switch (currentLevel)
            {
                case "Level 1":     spawner(mushroom, bush, pinecord);    break;
                case "Level 2":     spawner(mushroom, bush, cat);         break;
                case "Level 3":     spawner(bush, trashcan, pinecord);    break;
                case "Level 4":     spawner(mushroom, trashcan, cat);     break;
                case "Level 5":     spawner(pinecord, trashcan, cat);     break;
                default:            spawner(mushroom, bush, pinecord);    break;
            }
            controller.GetComponent<Controller>().isGameStarted = true;
            tempTime = 0f;
        }
        else
            tempTime += Time.deltaTime;
    }

    private void makeRandomSpawnLocation()
    {
        spawnLocation.y = Random.Range(-7.5f, 7.5f);
        spawnLocation.x = sign * (Ellipse_b / Ellipse_a) * Mathf.Sqrt(Mathf.Pow(Ellipse_a, 2) - Mathf.Pow(spawnLocation.y, 2));
        sign = -sign;
    }

    private void setEnemyAttributes()
    {
        EnemyMechanics enemyMechanicsInfo = enemy.GetComponent<EnemyMechanics>();
        enemyMechanicsInfo.spawnLocation = spawnLocation;

        //Set health of enemies according to their name
        switch (enemy.name)
        {
            case "mushroom":    enemyMechanicsInfo.enemyHealth = 100;   enemyMechanicsInfo.EnemySpeed = 0.25f;   break;
            case "bush":        enemyMechanicsInfo.enemyHealth = 150;   enemyMechanicsInfo.EnemySpeed = 0.2f;   break;
            case "trashcan":    enemyMechanicsInfo.enemyHealth = 250;   enemyMechanicsInfo.EnemySpeed = 0.1f;   break;
            case "pinecord":    enemyMechanicsInfo.enemyHealth = 350;   enemyMechanicsInfo.EnemySpeed = 0.1f;   break;
            case "cat":         enemyMechanicsInfo.enemyHealth = 200;   enemyMechanicsInfo.EnemySpeed = 0.3f;   break;
            default:            enemyMechanicsInfo.enemyHealth = 100;   enemyMechanicsInfo.EnemySpeed = 0.25f;   break;
        }
        enemyMechanicsInfo.enemyType = enemy.name;
        enemyMechanicsInfo.attackRate = 1;
    }

    //Level 1 Spawner
    private void spawner(GameObject enemy1, GameObject enemy2, GameObject enemy3)
    {
        if (enemyCount % 3 == 0 && enemyCount % 10 != 0)
        {
            enemy = enemy2;
        }
        else if (enemyCount % 5 == 0 && enemyCount > 0)
        {
            enemy = enemy3;
        }
        else
        {
            enemy = enemy1;
        }
        makeRandomSpawnLocation();

        setEnemyAttributes();

        Instantiate(enemy, spawnLocation, new Quaternion(0, 0, 0, 0));
        enemyCount++;
    }
}
