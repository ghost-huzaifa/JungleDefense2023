using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMechanics : MonoBehaviour
{
    public float EnemySpeed = 0.5f, recoilSpeed = 1.0f, enemyHealth = 100;
    public Vector3 spawnLocation;

    private float recoilDuration = 1.0f, tempTime = 0, step;
    public bool isShoot = false;

    Vector3 templeLocation = Vector3.zero;

    void Start()
    {
        templeLocation = GameObject.Find("Gun_Sprite").transform.position;
    }
    void Update()
    {
        if (isShoot == true)
        {
            tempTime += Time.deltaTime;
            if (tempTime > recoilDuration)
            {
                isShoot = false;
                tempTime = 0;
            }
        }
        moveEnemy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            isShoot = true;
            tempTime = 0;
            enemyHealth -= 40;
            if (enemyHealth <= 0)
                Destroy(gameObject);
        }
    }

    void moveEnemy()
    {
        if (isShoot)
            moveRecoil();
        else
            moveTowardsTemple();
    }

    void moveTowardsTemple()
    {
        step = EnemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, templeLocation, step);
    }

    void moveRecoil()
    {
        step = recoilSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, spawnLocation, step);
        
    }
}
