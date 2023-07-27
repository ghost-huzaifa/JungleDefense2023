using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float Enemy_spawn_rate = 1;

    private float time, Ellipse_a = 7.5f, Ellipse_b = 4f;
    private int sign = -1;
    private Vector2 spawn_location;

    void Start()
    {
        time = 0f;
        enemy.transform.Rotate(0, 0, 0);    
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
        spawn_location.y = Random.Range(-7.5f, 7.5f);
        spawn_location.x = sign * (Ellipse_b / Ellipse_a) * Mathf.Sqrt(Mathf.Pow(Ellipse_a, 2) - Mathf.Pow(spawn_location.y, 2));
        Instantiate(enemy, new Vector3(spawn_location.x, spawn_location.y, 0), new Quaternion (0,0,0,0));

        sign = -sign;
    }
}
