using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSystem
{
    public float boost = 150;
    public bool outOfBoost = false;

    public void SetBoost(float points)
    {
        boost = points;
    }

    public void BoostDown()
    {
        if (!outOfBoost && boost > 0)
        {
            boost -= 2;
        }
        else if (boost <= 0)
        {
            outOfBoost = true;
        }
    }
}
