using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMechanics : MonoBehaviour
{
    //Enemy Attributes
    public float EnemySpeed, recoilDuration = 0.1f, recoilAcceleration = 2, recoilSpeed = 2, enemyHealth, attackRate = 0.5f, bulletDamage = 30, maxHealth;
    public Vector3 spawnLocation;
    public string enemyType;
    public bool isShoot = false, isMoving = true, isAttacking = false, isDying = false, isGameOver = false;
    public GameObject healthBarObj;
    public Controller controller;
    public Collider2D enemyCollider;

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

        //Get Game Controller Script
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();

        //Set Maximum Health
        maxHealth = enemyHealth;
    }
    void Update()
    {
        if (isGameOver)
        {
            isMoving = false;
            isAttacking = false;
            isShoot = false;
            isDying = false;
        }
        else
        {


            //Check if enemy is being shoot, if yes, stop moving for recoilDuration
            if (isShoot && !isDying)
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
            if (isMoving && !isDying)
                moveEnemy();
            else if (isAttacking && !isDying)
            {
                tempTime += Time.deltaTime;
                if (tempTime > (1 / attackRate))
                {
                    if (castle)     //Check if castle is destroyed
                        attack(castle);
                    tempTime = 0;
                }
            }


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            //Check if enemy is hit by fireball, then destroy enemy
            case "fireBall":
                die();
                break;
            //Check if enemy is hit by bullet, and deal damage to enemy
            case "bullet":
                isShoot = true;
                tempTime = 0;
                step = recoilSpeed * Time.deltaTime;
                moveRecoil();
                enemyHealth -= bulletDamage;
                controller.addScore((int)bulletDamage);
                healthBar.decreaseHealthbar(bulletDamage);
                if (enemyHealth <= 0)
                    die();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
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
        castle.GetComponent<HealthBar>().decreaseHealthbar(50);
    }

    public void dealLighteningDamage()
    {
        float damage = 0;
        moveRecoil();
        isShoot = true;
        tempTime = 0;
        step = recoilSpeed * Time.deltaTime;
        
        switch (enemyType)
        {
            case "mushroom":    damage = 30;    break;
            case "bush":        damage = 30;    break;
            case "trashcan":    damage = 15;    break;
            case "pinecord":    damage = 15;    break;
            case "cat":         damage = 40;    break;
            default:            damage = 30;    break;
        }
        enemyHealth -= damage;
        healthBar.decreaseHealthbar(damage);
        controller.addScore((int)damage);
        if (enemyHealth <= 0)
            die();
    }

    public void die()
    {
        //Add score to player
        controller.addScore((int)maxHealth);

        //set controller of animator to death Effect
        gameObject.GetComponent<Animator>().SetBool("Die", true);
        healthBarObj.SetActive(false);
        //Disable all type of collider on enemy
        enemyCollider.enabled = false;
        isDying = true;
        isMoving = false;
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
