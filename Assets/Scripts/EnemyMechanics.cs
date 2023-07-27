using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMechanics : MonoBehaviour
{
    public float EnemySpeed = 1f;
    private float enemyHealth = 0;

    void Start()
    {
        switch(gameObject.tag)
        {
            case "easyLevelEnemy":
                enemyHealth = 100;
                break;
            case "mediumLevelEnemy":
                enemyHealth = 200;
                break;
            case "hardLevelEnemy":
                enemyHealth = 400;
                break;
        }
    }

    void Update()
    {
        var step = EnemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
            enemyHealth -= 100;
        if (enemyHealth <= 0)
            Destroy(gameObject);
    }
}
