using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool autoForward;
    public bool noForward;
    public Rigidbody rigidBody;
    public float forwardVelocityMultiplier = 1.4f;
    public float sidewayVelocityMultiplier = 1.2f;

    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = transform;
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //velocityMultiplier = 1.4f;
    }

    private void Update()
    {
        //print(playerTransform.position);
    }

    public void Forward(Vector3 inputVector)
    {
        if(autoForward)
            rigidBody.AddForce(new Vector3(0, 0, 1) * 2, ForceMode.VelocityChange);
        else if (noForward) { }

        else
            rigidBody.AddForce(inputVector * forwardVelocityMultiplier, ForceMode.Impulse);
        //rigidBody.velocity = inputVector * velocityMultiplier;
    }

    public void Backward(Vector3 inputVector)
    {
        rigidBody.AddForce(inputVector * forwardVelocityMultiplier, ForceMode.Impulse);
        //rigidBody.velocity = inputVector * velocityMultiplier;
    }

    public void Left(Vector3 inputVector)
    {
        rigidBody.AddForce(inputVector * sidewayVelocityMultiplier, ForceMode.Impulse);
        //rigidBody.velocity = inputVector * velocityMultiplier;
    }

    public void Right(Vector3 inputVector)
    {
        rigidBody.AddForce(inputVector * sidewayVelocityMultiplier, ForceMode.Impulse);
        //rigidBody.velocity = inputVector * velocityMultiplier;
    }

    public void Rise(Vector3 inputVector)
    {
        // TODO: Add flight movement; flying upwards.
    }
}
