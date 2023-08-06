using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate = 1f;

    private float tempTime = 0;

    
    void Update()
    {
        if (tempTime > (1/fireRate) && (Input.touchCount > 0 || Input.GetMouseButtonUp(0)))
        {
            shoot();
            tempTime = 0f;
        }
        else
        {
            tempTime += Time.deltaTime;
        }
    }

    private void shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
