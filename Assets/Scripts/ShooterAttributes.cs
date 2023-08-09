using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAttributes
{
    private Sprite shooterSprite;
    private float minAngle = 0;     //inclusive
    private float maxAngle = 0;     //exclusive

    public void setSprite(Sprite sprite)
    {
        this.shooterSprite = sprite;
    }

    public void setMinAngle(float minAngle)
    {
        this.minAngle = minAngle;
    }

    public void setMaxAngle(float maxAngle)
    {
        this.maxAngle = maxAngle;
    }

    public float getMaxAngle()
    {
        return this.maxAngle;
    }

    public float getMinAngle()
    {
        return this.minAngle;
    }

    public Sprite getSprite()
    {
        return this.shooterSprite;
    }
}
