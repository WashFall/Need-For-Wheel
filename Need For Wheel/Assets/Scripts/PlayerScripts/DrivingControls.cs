using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingControls : Controls
{
    public float forwardSpeed = 15;

    private bool speedPower = false;
    private float startTime;
    private float endTime;

    public override void Forward(Vector3 inputVector) 
    {
        if (player.autoForward)
            player.rigidBody.AddRelativeForce(new Vector3(0, 0, 1) * forwardSpeed, ForceMode.Impulse);
        else if (player.noForward) { }
        else
            player.rigidBody.AddRelativeForce(inputVector * player.forwardVelocityMultiplier, ForceMode.Impulse);
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

    public void SpeedPowerUp()
    {
        startTime = Time.time;
        endTime = Time.time + 5;
        speedPower = true;
    }

    private void Update()
    {
        if (speedPower)
        {
            startTime = Time.time;
            if(startTime < endTime)
            {
                forwardSpeed = 25f;
            }
            else if(endTime < startTime)
            {
                forwardSpeed = 15f;
                speedPower = false;
            }
        }
        Debug.Log(forwardSpeed);
    }
}
