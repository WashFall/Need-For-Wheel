using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool autoForward;
    public Rigidbody rigidBody;

    private float vertical;
    private float horizontal;
    private float velocityMultiplier;
    private Vector3 velocity;
    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = transform;
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        velocityMultiplier = 1.4f;
    }

    private void Update()
    {
        //print(velocity);
    }

    public void Forward(Vector3 inputVector)
    {
        velocity.z = inputVector.z;

        if(autoForward)
            rigidBody.AddForce(new Vector3(0, 0, 1) * 2, ForceMode.VelocityChange);
        else
            rigidBody.AddForce(velocity * velocityMultiplier, ForceMode.Impulse);
        //rigidBody.velocity = inputVector * velocityMultiplier;
    }

    public void Backward(Vector3 inputVector)
    {
        velocity.z = inputVector.z;

        rigidBody.AddForce(velocity * velocityMultiplier, ForceMode.Impulse);
        //rigidBody.velocity = inputVector * velocityMultiplier;
    }

    public void Left(Vector3 inputVector)
    {
        velocity.x = inputVector.x;

        rigidBody.AddForce(velocity * velocityMultiplier, ForceMode.Impulse);
        //rigidBody.velocity = inputVector * velocityMultiplier;
    }

    public void Right(Vector3 inputVector)
    {
        velocity.x = inputVector.x;

        rigidBody.AddForce(velocity * velocityMultiplier, ForceMode.Impulse);
        //rigidBody.velocity = inputVector * velocityMultiplier;
    }
}
