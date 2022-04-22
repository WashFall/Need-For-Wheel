using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool dead;
    public bool noForward;
    public bool autoForward;
    public Rigidbody rigidBody;
    public bool increaseGravity;
    public float forwardVelocityMultiplier = 1.4f;
    public float sidewayVelocityMultiplier = 1.2f;

    private void Awake()
    {
        dead = false;
        rigidBody = GetComponent<Rigidbody>();
        if(increaseGravity)
            Physics.gravity = new Vector3(0, -40, 0);
    }

    public void Forward(Vector3 inputVector)
    {
        if(autoForward)
            rigidBody.AddForce(new Vector3(0, 0, 1) * 1.5f, ForceMode.VelocityChange);
        else if (noForward) { }
        else
            rigidBody.AddForce(inputVector * forwardVelocityMultiplier, ForceMode.Impulse);
    }

    public void Backward(Vector3 inputVector)
    {
        rigidBody.AddForce(inputVector * forwardVelocityMultiplier, ForceMode.Impulse);
    }

    public void Left(Vector3 inputVector)
    {
        rigidBody.AddForce(inputVector * sidewayVelocityMultiplier, ForceMode.Impulse);
    }

    public void Right(Vector3 inputVector)
    {
        rigidBody.AddForce(inputVector * sidewayVelocityMultiplier, ForceMode.Impulse);
    }

    public void Rise(Vector3 inputVector)
    {
        // TODO: Add flight movement; flying upwards.
        rigidBody.AddForce(inputVector * 12, ForceMode.Impulse);
    }

    public void GravitySwitch()
    {
        increaseGravity = increaseGravity ? false : true;

        if (increaseGravity)
        {
            Physics.gravity = new Vector3(0, -40, 0);
        }
        else
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
        }
    }
}
