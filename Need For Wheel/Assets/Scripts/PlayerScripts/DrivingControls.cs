using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingControls : Controls
{
    public float forwardSpeed = 15;

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
}
