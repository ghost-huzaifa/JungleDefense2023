using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Powerups : MonoBehaviour
{
    public float lighteningCooldownTime = 5, fireBallCooldownTime = 7;
    public GameObject lighteningButton, fireBallButton;
    public bool fireBallTrigger = false;

    private float lighteningTempTime, fireBallTempTime;
    private bool isLighteningCooldown = false, isFireBallCooldown = false;
    private void Start()
    {
        lighteningButton = GameObject.FindGameObjectWithTag("lighteningButton");
        fireBallButton = GameObject.FindGameObjectWithTag("fireBallButton");
        lighteningTempTime = 0;
        fireBallTempTime = 0;
    }

    private void Update()
    {
        lighteningTempTime += Time.deltaTime;
        fireBallTempTime += Time.deltaTime;
        if (lighteningTempTime >= lighteningCooldownTime)
        {
            lighteningTempTime = 0;
            isLighteningCooldown = false;
            lighteningButton.GetComponent<Button>().interactable = true;
        }
        if (fireBallTempTime >= fireBallCooldownTime)
        {
            fireBallTempTime = 0;
            isFireBallCooldown = false;
            fireBallButton.GetComponent<Button>().interactable = true;
        }
    }
    public void lighteningPowerup()
    {
        if (!isLighteningCooldown)
        {
            dealLighteningDamage();
            isLighteningCooldown = true;
            lighteningButton.GetComponent<Button>().interactable = false;
            makeLighteningAnimation();
        }
    }

    public void makeLighteningAnimation()
    {
        int animPattern = Random.Range(1, 2);
        gameObject.GetComponent<Animator>().SetTrigger("Pattern" + animPattern);
    }

    private void dealLighteningDamage()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyMechanics>().dealLighteningDamage();
        }
    }    

    public void fireBallPowerup()
    {
        if (!isFireBallCooldown)
        {
            fireBallTrigger = true;
            isFireBallCooldown = true;
            fireBallButton.GetComponent<Button>().interactable = false;
            //makeFireBallAnimation();
        }
    }

    
}
