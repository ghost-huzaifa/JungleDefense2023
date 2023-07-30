using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Player : MonoBehaviour
{
    public GameObject player;
    public float senstivity = 1f;
    private Vector3 turn = Vector3.zero;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Convert touch position to world space
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f; // Assuming your object is in 2D, set the z-coordinate to zero

            // Calculate the direction to the touch position
            Vector3 direction = touchPosition - transform.position;

            // Calculate the angle between the object's forward direction and the direction to the touch position
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

            // Apply the rotation
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
