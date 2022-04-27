using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingControls : Controls
{
    public override void Forward(Vector3 inputVector)
    {
        player.rigidBody.AddRelativeForce(inputVector * 12, ForceMode.Impulse);
    }

    public override void Backward(Vector3 inputVector)
    {

    }

    public override void Left(Vector3 inputVector)
    {

    }

    public override void Right(Vector3 inputVector)
    {

    }
}
