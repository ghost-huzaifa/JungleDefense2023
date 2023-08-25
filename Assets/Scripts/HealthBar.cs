using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite mediumHealthbar, lowHealthbar;
    public Image healthBarSprite;
    public float reduceSpeed = 0.5f;

    private GameObject controller;
    private GameObject healthbarImage;
    private float target = 1, maxHealth, currentHealth;

    private void Start()
    {

        if (gameObject.tag == "castle")
        {
            healthbarImage = GameObject.FindGameObjectWithTag("healthbarBackground");
            controller = GameObject.FindGameObjectWithTag("GameController");
            maxHealth = 1000f;
            currentHealth = 1000f;
        }
    }
    public void decreaseHealthbar(float damage)
    {
        currentHealth -= damage;
        target = currentHealth / maxHealth;
    }

    void Update()
    {
        healthBarSprite.fillAmount = Mathf.MoveTowards(healthBarSprite.fillAmount, target, reduceSpeed * Time.deltaTime);
        if (healthBarSprite.fillAmount <= 0)
        {
            gameObject.GetComponent<HealthBar>().enabled = false;
        }
        if (gameObject.tag == "castle")
        {
            if (healthBarSprite.fillAmount <= 0)
            {
                controller.GetComponent<Controller>().gameOver();
                controller.GetComponent<Controller>().earnedStars = 0;
            }
            else if (healthBarSprite.fillAmount <= 0.33f)
            {
                healthbarImage.GetComponent<Image>().sprite = lowHealthbar;
                controller.GetComponent<Controller>().earnedStars = 1;
            }
            else if (healthBarSprite.fillAmount <= 0.66f)
            {
                healthbarImage.GetComponent<Image>().sprite = mediumHealthbar;
                controller.GetComponent<Controller>().earnedStars = 2;
            }
        }
    }
    
    public void setMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
    }
}
