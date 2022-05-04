using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightStamina
{
    public bool outOfStamina = false;
    public float stamina = 150;

    public void StaminaDown()
    {
        if (!outOfStamina && stamina > 0)
        {
            stamina -= 2;
        }
        else if (stamina <= 0)
        {
            outOfStamina = true;
        }
    }

    public void StaminaUp()
    {
        stamina++;

        if(stamina > 0)
            outOfStamina = false;
    }
}
