using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Powerups : MonoBehaviour
{
    public float cooldownTime = 5;
    public GameObject lighteningButton;

    private float tempTime;
    private bool isCooldown = false;
    private void Start()
    {
        lighteningButton = GameObject.FindGameObjectWithTag("lighteningButton");
        tempTime = 0;
    }

    private void Update()
    {
        tempTime += Time.deltaTime;
        if (tempTime >= cooldownTime)
        {
            tempTime = 0;
            isCooldown = false;
            lighteningButton.GetComponent<Button>().interactable = true;
        }
    }
    public void lighteningPowerup()
    {
        if (!isCooldown)
        {
            int animationNo = Random.Range(1, 3);
            gameObject.GetComponent<Animator>().SetTrigger("Trigger" + animationNo.ToString());
            isCooldown = true;
            lighteningButton.GetComponent<Button>().interactable = false;
        }
    }
}
