using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSystem
{
    public bool outOfBoost = false;
    public float boost = 150;

    public void StaminaDown()
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

    public void StaminaUp()
    {
        boost++;

        if(boost > 0)
            outOfBoost = false;
    }
}
