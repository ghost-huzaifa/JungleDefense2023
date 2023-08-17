using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject bullet, fireBall;
    public Transform firePoint;
    public float fireRate = 1f;

    private Vector3 worldMousePosition;
    private float tempTime = 0;

    Shooter shooterInfo;

    void Start()
    {
         shooterInfo = GameObject.FindGameObjectWithTag("shooter").GetComponent<Shooter>();
    }

    void Update()
    {
        if (tempTime > (1/fireRate) && (Input.touchCount > 0 || Input.GetMouseButtonUp(0)))
        {
            worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                shooterInfo.makeRotationAndroid();
                shoot();
                tempTime = 0f;
            }
        }
        else
        {
            tempTime += Time.deltaTime;
        }
    }

    private void shoot()
    {
        Powerups powerupsInfo = GameObject.FindGameObjectWithTag("powerups").GetComponent<Powerups>();
        if (powerupsInfo.fireBallTrigger)
        {
            Instantiate(fireBall, firePoint.position, firePoint.rotation);
            powerupsInfo.fireBallTrigger = false;
        }
        else
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }

    }
}
