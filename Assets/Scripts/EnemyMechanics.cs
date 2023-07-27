using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMechanics : MonoBehaviour
{
    public float EnemySpeed = 1f;
    void Update()
    {
        var step = EnemySpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
