using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject easyLevelEnemy, mediumLevelEnemy, hardLevelEnemy;
    public float Enemy_spawn_rate = 1;

    private float time, Ellipse_a = 7.5f, Ellipse_b = 4f;
    private int sign = -1, enemyCount = 0;
    private Vector2 spawn_location = Vector2.zero;

    void Start()
    {
        time = 0f;   
    }

    void Update()
    {
        if (time > Enemy_spawn_rate)
        {
            create_enemy();
            time = 0f;
        }
        else
        {
            time += Time.deltaTime;
        }
    }

    private void create_enemy()
    {
        makeRandomSpawnLocation();

        if (enemyCount % 5 == 0 && enemyCount %10 != 0)
        {
            Instantiate(mediumLevelEnemy, new Vector3(spawn_location.x, spawn_location.y, 0), new Quaternion(0, 0, 0, 0));

        }
        else if (enemyCount % 10 == 0 && enemyCount > 0)
        {
            Instantiate(hardLevelEnemy, new Vector3(spawn_location.x, spawn_location.y, 0), new Quaternion(0, 0, 0, 0));
        }
        else
            Instantiate(easyLevelEnemy, new Vector3(spawn_location.x, spawn_location.y, 0), new Quaternion(0, 0, 0, 0));
        enemyCount++;
    }

    private void makeRandomSpawnLocation()
    {
        spawn_location.y = Random.Range(-7.5f, 7.5f);
        spawn_location.x = sign * (Ellipse_b / Ellipse_a) * Mathf.Sqrt(Mathf.Pow(Ellipse_a, 2) - Mathf.Pow(spawn_location.y, 2));
        sign = -sign;
    }

    private void spawnEnemy(string name)
    {
        Instantiate(GameObject.Find(name), new Vector3(spawn_location.x, spawn_location.y, 0), new Quaternion(0, 0, 0, 0));
    }

}
