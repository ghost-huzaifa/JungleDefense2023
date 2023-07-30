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
        if (Mathf.Abs(transform.position.y) > 6.0f || Mathf.Abs(transform.position.x) > 3.0f)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
            Destroy(gameObject);
    }


}
