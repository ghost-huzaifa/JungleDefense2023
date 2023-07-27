using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        turn.z += Input.GetAxis("Mouse X") * senstivity;
        transform.rotation = Quaternion.Euler(0, 0, -turn.z);
    }
}
