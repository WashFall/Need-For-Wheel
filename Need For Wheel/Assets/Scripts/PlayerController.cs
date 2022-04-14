using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool autoForward;
    public Rigidbody rigidBody;
    public float velocityMultiplier = 1.4f;

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
        else
            rigidBody.AddForce(inputVector * velocityMultiplier, ForceMode.Impulse);
        //rigidBody.velocity = inputVector * velocityMultiplier;
    }

    public void Backward(Vector3 inputVector)
    {
        rigidBody.AddForce(inputVector * velocityMultiplier, ForceMode.Impulse);
        //rigidBody.velocity = inputVector * velocityMultiplier;
    }

    public void Left(Vector3 inputVector)
    {
        rigidBody.AddForce(inputVector * velocityMultiplier, ForceMode.Impulse);
        //rigidBody.velocity = inputVector * velocityMultiplier;
    }

    public void Right(Vector3 inputVector)
    {
        rigidBody.AddForce(inputVector * velocityMultiplier, ForceMode.Impulse);
        //rigidBody.velocity = inputVector * velocityMultiplier;
    }
}
