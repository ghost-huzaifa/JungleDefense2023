using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Bullet_Mechanics : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.up * speed;    
    }

    void Update()
    {
        if ((transform.position.y > 0.5f || transform.position.y < -0.4f) || Mathf.Abs(transform.position.x) > 0.6f)
            gameObject.GetComponent<SpriteRenderer>().enabled = true;

        if (Mathf.Abs(transform.position.y) > 6.0f || Mathf.Abs(transform.position.x) > 3.0f)
            Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }


}
