using UnityEngine;

public class BoostSystem
{
    public static float boost = 0;

    public bool outOfBoost = false;

    private int step = 0;
    private int oldStep = 0;

    public void SetBoost(float points)
    {
        boost = points;
    }

    public void BoostDown()
    {
        if (!outOfBoost && boost > 0)
        {
            boost -= 3;
        }
        else if (boost <= 0)
        {
            outOfBoost = true;
        }
    }

    public void BoostUp(float position)
    {
        if(PlayerController.State == PlayerState.Driving)
        {
            step = Mathf.RoundToInt(position / 100);

            if(step > oldStep)
            {
                boost += 40;
                oldStep = step;
            }
        }
    }
}
