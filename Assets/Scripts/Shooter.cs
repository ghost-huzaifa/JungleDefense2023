using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;



public class Shooter : MonoBehaviour
{
    public Transform firePoint;

    //import all shooter sprites as reference
    public Sprite[] sprites = new Sprite[8];


    //create all instances of our shooter
    private ShooterAttributes[] ballShooter = new ShooterAttributes[8]; 


    //variables used in the script
    private double angle = 0;


    void Start()
    {
        setShooterAttributes();
    }

    void Update()
    {
        //makeRotationAndroid();

        makeRotationPC();

        checkSprite();
    }

    //check which sprite to use according to the rotation of the shooter
    void checkSprite()
    {
        
        for (int i = 1; i < ballShooter.Length; i++)
        {
            if (angle >= ballShooter[i].getMinAngle() && angle < ballShooter[i].getMaxAngle())
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = ballShooter[i].getSprite();
            }
            else if ((angle >= ballShooter[0].getMinAngle() && angle < 360) || (angle >= 0 && angle < ballShooter[0].getMaxAngle()))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = ballShooter[0].getSprite();
            }
        }
    }


    //rotate the shooter according to the mouse position for android
    void makeRotationAndroid()
    {
        Touch touch = Input.GetTouch(0);

        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        touchPosition.z = 0f;

        Vector3 direction = touchPosition - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        firePoint.transform.rotation = Quaternion.AngleAxis((float)angle - 90, Vector3.forward);
    }

    //rotate the shooter according to the mouse position for PC

    void makeRotationPC()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        angle = Mathf.Atan2(worldMousePosition.y, worldMousePosition.x) * Mathf.Rad2Deg;
        if (angle < 0)
        {
            angle += 360;
        }

        firePoint.transform.rotation = Quaternion.AngleAxis((float)angle - 90, Vector3.forward);
    }


    void setShooterAttributes()
    {
        for (int i = 0; i < ballShooter.Length; i++)
        {
            ballShooter[i] = new ShooterAttributes();
            ballShooter[i].setSprite(sprites[i]);
            
            float minAngle = (i * 45) - 22.5f;

            if (minAngle < 0)
            {
                minAngle += 360;
            }
            float maxAngle = (i * 45) + 22.5f;

            ballShooter[i].setMinAngle(minAngle);
            ballShooter[i].setMaxAngle(maxAngle);
        }
    }
}
