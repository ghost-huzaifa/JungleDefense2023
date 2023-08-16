using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite mediumHealthbar, lowHealthbar;
    public Image healthBarSprite;
    public float reduceSpeed = 0.5f;

    private GameObject healthbarImage;
    private float target = 1, maxHealth, currentHealth;

    private void Start()
    {
        if (gameObject.tag == "castle")
        {
            healthbarImage = GameObject.FindGameObjectWithTag("healthbarBackground");
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
            Destroy(gameObject);
        }
        if (gameObject.tag == "castle")
        {
            if (healthBarSprite.fillAmount <= 0.66f)
            {
                healthbarImage.GetComponent<Image>().sprite = mediumHealthbar;
            }
            if (healthBarSprite.fillAmount <= 0.33f)
            {
                healthbarImage.GetComponent<Image>().sprite = lowHealthbar;
            }
        }
    }
    
    public void setMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
    }
}
