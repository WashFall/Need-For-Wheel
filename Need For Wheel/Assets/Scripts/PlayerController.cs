using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool dead;
    public bool rotate;
    public bool noForward;
    public bool autoForward;
    public Rigidbody rigidBody;
    public bool increaseGravity;
    public float forwardVelocityMultiplier = 10;
    public float sidewayVelocityMultiplier = 5;

    private void Awake()
    {
        dead = false;
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rotate)
        {
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, 0.5f, -(transform.up), out hit, 10, 5))
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, hit.transform.rotation , 2 * Time.deltaTime);
                
            }
        }
    }

    public void Forward(Vector3 inputVector)
    {
        if(autoForward)
            rigidBody.AddRelativeForce(new Vector3(0, 0, 1) * 1.5f, ForceMode.VelocityChange);
        else if (noForward) { }
        else
            rigidBody.AddRelativeForce(inputVector * forwardVelocityMultiplier, ForceMode.Impulse);
    }

    public void Backward(Vector3 inputVector)
    {
        rigidBody.AddRelativeForce(inputVector * forwardVelocityMultiplier, ForceMode.Impulse);
    }

    public void Left(Vector3 inputVector)
    {
        rigidBody.AddRelativeForce(inputVector * sidewayVelocityMultiplier, ForceMode.Impulse);
    }

    public void Right(Vector3 inputVector)
    {
        rigidBody.AddRelativeForce(inputVector * sidewayVelocityMultiplier, ForceMode.Impulse);
    }

    public void Rise(Vector3 inputVector)
    {
        // TODO: Add flight movement; flying upwards.
        rigidBody.AddRelativeForce(inputVector * 12, ForceMode.Impulse);
        
    }

    public void GravitySwitch()
    {
        increaseGravity = increaseGravity ? false : true;
    }
}
