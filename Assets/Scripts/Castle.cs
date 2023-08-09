using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    
    public void CollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<EnemyMechanics>().attack(gameObject);
        }
        Debug.Log("Hitted: " + collision.gameObject.name);
        
    }
}
