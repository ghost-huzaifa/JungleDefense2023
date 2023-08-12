using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMechanics : MonoBehaviour
{
    //Enemy Attributes
    public float EnemySpeed = 0.5f, recoilDuration = 0.1f, recoilAcceleration = 2, recoilSpeed = 2, enemyHealth = 100, attackRate = 0.5f, bulletDamage = 50;
    public Vector3 spawnLocation;
    public string enemyType;
    public bool isShoot = false, isMoving = true, isAttacking = false;

    //Script Variables
    private HealthBar healthBar;
    private float tempTime = 0, step;
    Powerups powerupsInfo;
    GameObject castle;
    Vector3 castleLocation = new  Vector3(1,0,0);

    void Start()
    {
        //Get Castle Location
        castle = GameObject.FindGameObjectWithTag("castle");
        castleLocation = castle.transform.position;

        //Get Healthbar script
        healthBar = gameObject.GetComponent<HealthBar>();
        healthBar.setMaxHealth(enemyHealth);
    }
    void Update()
    {
        //Check if enemy is being shoot, if yes, stop moving for recoilDuration
        if (isShoot)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.316f, 0.316f);
            tempTime += Time.deltaTime;
            if (tempTime > recoilDuration)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                isShoot = false;
                isMoving = true;
                tempTime = 0;
            }
        }

        //Check if enemy is moving or attacking
        if (isMoving)
            moveEnemy();
        else if (isAttacking)
        {
            tempTime += Time.deltaTime;
            if (tempTime > (1/attackRate))
            {
                if (castle)     //Check if castle is destroyed
                    attack(castle);
                tempTime = 0;
            }
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            //Check if enemy is hit by fireball, then destroy enemy
            case "fireBall":
                Destroy(gameObject);
                break;
            //Check if enemy is hit by bullet, and deal damage to enemy
            case "bullet":
                isShoot = true;
                tempTime = 0;
                step = recoilSpeed * Time.deltaTime;
                enemyHealth -= bulletDamage;
                healthBar.decreaseHealthbar(bulletDamage);
                if (enemyHealth <= 0)
                    Destroy(gameObject);
                break;
            //Check if enemy is hit by castle, then stops moving and deal damage to castle
            case "castle":
                stopMoving();
                isAttacking = true;
                if (collision.gameObject)   //Check if castle is destroyed
                {
                    attack(collision.gameObject);
                }
                break;
         }
    }

    void moveEnemy()
    {
        if (isShoot)
            moveRecoil();
        //stopMoving();
        else
            moveTowardsCastle();
    }
    
    void moveTowardsCastle()
    {
        step = EnemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, castleLocation, step);
    }

    void stopMoving()
    {
        isMoving = false;
    }

    void moveRecoil()
    {
        isMoving = true;
        step /= recoilAcceleration; //Decelerate
        transform.position = Vector3.MoveTowards(transform.position, spawnLocation, step);
    }

    //Dealt damage to castle on each hit after certain time
    public void attack(GameObject castle)
    {
         switch(enemyType)
         {
             case "easyEnemy":
                 castle.GetComponent<HealthBar>().decreaseHealthbar(50);
                 break;
             case "mediumEnemy":
                castle.GetComponent<HealthBar>().decreaseHealthbar(75);
                break;
             case "hardEnemy":
                castle.GetComponent<HealthBar>().decreaseHealthbar(100);
                break;
         }
    }

    public void dealLighteningDamage()
    {
        float damage = 0;
        isShoot = true;
        tempTime = 0;
        step = recoilSpeed * Time.deltaTime;
        
        switch (enemyType)
        {
            case "easyEnemy":
            case "mediumEnemy":
                damage = 25;
                break;
            case "hardEnemy":
                damage = 75;
                break;
        }
        enemyHealth -= damage;
        healthBar.decreaseHealthbar(damage);
        if (enemyHealth <= 0)
            Destroy(gameObject);
    }
}
