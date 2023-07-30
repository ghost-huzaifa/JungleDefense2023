using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject easyLevelEnemy, mediumLevelEnemy, hardLevelEnemy;
    public float Enemy_spawn_rate = 1;

    private GameObject enemy;
    private float tempTime, health, Ellipse_a = 7.5f, Ellipse_b = 4f;
    private int sign = -1, enemyCount = 0;
    private Vector3 spawnLocation = Vector3.zero;

    void Start()
    {
        tempTime = 0f;
        enemy.transform.Rotate(0, 0, 0);    
    }


    void Update()
    {
        if (tempTime > Enemy_spawn_rate)
        {
            create_enemy();
            tempTime = 0f;
        }
        else
        {
            tempTime += Time.deltaTime;
        }
    }

    private void create_enemy()
    {
        Debug.Log(enemyCount);
        if (enemyCount % 5 == 0 && enemyCount % 10 != 0)
        {
            enemy = mediumLevelEnemy;
            health = 200;
        }
        else if (enemyCount % 10 == 0 && enemyCount > 0)
        {
            enemy = hardLevelEnemy;
            health = 400;
        }
        else
        {
            enemy = easyLevelEnemy;
            health = 100;
        }
        makeRandomSpawnLocation();

        setEnemyAttributes();

        Instantiate(enemy, spawnLocation, new Quaternion(0, 0, 0, 0));
        enemyCount++;
    }
    private void makeRandomSpawnLocation()
    {
        spawnLocation.y = Random.Range(-7.5f, 7.5f);
        spawnLocation.x = sign * (Ellipse_b / Ellipse_a) * Mathf.Sqrt(Mathf.Pow(Ellipse_a, 2) - Mathf.Pow(spawnLocation.y, 2));
        sign = -sign;
    }

    private void setEnemyAttributes()
    {
        enemy.GetComponent<EnemyMechanics>().spawnLocation = spawnLocation;
        enemy.GetComponent<EnemyMechanics>().enemyHealth = health;
    }


}
