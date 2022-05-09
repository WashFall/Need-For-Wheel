using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingControls : Controls
{
    public float risePower = 5;
    public float divePower = 3;
    public float flightSpeed = 3;

    public override void Forward(Vector3 inputVector) //Rise
    {
        player.rigidBody.AddRelativeForce(inputVector * risePower, ForceMode.Impulse);
    }

    public override void Backward(Vector3 inputVector) //Dive
    {
        player.rigidBody.AddForce(inputVector * divePower, ForceMode.Impulse);
    }

    public override void Left(Vector3 inputVector)
    {
        player.rigidBody.AddRelativeForce(inputVector * 3, ForceMode.Impulse);
    }

    public override void Right(Vector3 inputVector)
    {
        player.rigidBody.AddRelativeForce(inputVector * 3, ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        if(PlayerController.State == PlayerState.Flying)
            player.rigidBody.AddForce(new Vector3(0, 0, 0.5f), ForceMode.Impulse);
    }
}
