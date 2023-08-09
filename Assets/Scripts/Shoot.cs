using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate = 1f;

    private Vector3 worldMousePosition;
    private float tempTime = 0;

   
    void Update()
    {
        if (tempTime > (1/fireRate) && (Input.touchCount > 0 || Input.GetMouseButtonUp(0)))
        {
            worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(worldMousePosition);
            if (!((worldMousePosition.x > 1.44 && worldMousePosition.x < 2.44) && (worldMousePosition.y > -3.88 && worldMousePosition.y < -2.88)))
            {
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
        bullet.GetComponent<SpriteRenderer>().enabled = false;
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
