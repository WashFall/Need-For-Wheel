using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform playerTransform;
    public Rigidbody rigidBody;

    private float vertical;
    private float horizontal;
    private float velocityMultiplier;

    private void Awake()
    {
        playerTransform = transform;
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        velocityMultiplier = 100f;
    }

    public void Forward(Vector3 inputVector)
    {
        rigidBody.AddForce(inputVector * 75f, ForceMode.Force);
        //rigidBody.velocity = inputVector * velocityMultiplier;
    }

    public void Backward(Vector3 inputVector)
    {
        rigidBody.AddForce(inputVector * velocityMultiplier, ForceMode.Force);
        //rigidBody.velocity = inputVector * velocityMultiplier;
    }

    public void Left(Vector3 inputVector)
    {
        rigidBody.AddForce(inputVector * velocityMultiplier, ForceMode.Force);
        //rigidBody.velocity = inputVector * velocityMultiplier;
    }

    public void Right(Vector3 inputVector)
    {
        rigidBody.AddForce(inputVector * velocityMultiplier, ForceMode.Force);
        //rigidBody.velocity = inputVector * velocityMultiplier;
    }
}
