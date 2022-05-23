using UnityEngine;

public class DrivingControls : Controls
{
    public float forwardSpeed = 15;

    private float endTime;
    private float startTime;
    private bool speedPower = false;

    public override void Forward(Vector3 inputVector) // Changes forward movement based on bools
    {
        if (player.autoForward)
        {
            player.rigidBody.AddRelativeForce(new Vector3(0, 0, 1) * forwardSpeed, ForceMode.Impulse);
        }
        else if (player.noForward)
        {
            //Do nothing
        }
        else
        {
            player.rigidBody.AddRelativeForce(inputVector * player.forwardVelocityMultiplier, ForceMode.Impulse);
        }
    }

    public override void Backward(Vector3 inputVector) 
    {
        player.rigidBody.AddRelativeForce(inputVector * player.forwardVelocityMultiplier, ForceMode.Impulse);
    }

    public override void Left(Vector3 inputVector) 
    {
        player.rigidBody.AddRelativeForce(inputVector * player.sidewayVelocityMultiplier, ForceMode.Impulse);
    }

    public override void Right(Vector3 inputVector) 
    {
        player.rigidBody.AddRelativeForce(inputVector * player.sidewayVelocityMultiplier, ForceMode.Impulse);
    }

    public void SpeedPowerUp() // Gets called when a power up is picked up
    {
        endTime = Time.time + 5;
        startTime = Time.time;
        speedPower = true;
    }

    private void Update()
    {
        if (speedPower)
        {
            startTime = Time.time;

            if(startTime < endTime)
            {
                forwardSpeed = 20f;
            }
            else if(endTime < startTime)
            {
                forwardSpeed = 15f;
                speedPower = false;
            }
        }
    }
}
