using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Bullet_Mechanics : MonoBehaviour
{
    public float speed = 20f;
    public bool isFireBall = false;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.up * speed;    
    }

    void Update()
    {
        //continuously rotate the bullet along z-axis
        if (gameObject.tag != "fireBall" && gameObject.GetComponent<SpriteRenderer>().enabled)
            transform.Rotate(0, 0, 1f);


        if ((transform.position.y > 0.5f || transform.position.y < -0.4f) || Mathf.Abs(transform.position.x) > 0.6f)
            gameObject.GetComponent<SpriteRenderer>().enabled = true;

        if (Mathf.Abs(transform.position.y) > 6.0f || Mathf.Abs(transform.position.x) > 3.0f)
            Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy" && !(gameObject.tag == "fireBall"))
        {
            Destroy(gameObject);
        }
    }


}
