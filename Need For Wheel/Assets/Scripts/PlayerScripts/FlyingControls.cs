using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingControls : Controls
{
    public float risePower = 12;
    public float divePower = 6;

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

    }

    public override void Right(Vector3 inputVector)
    {

    }
}
