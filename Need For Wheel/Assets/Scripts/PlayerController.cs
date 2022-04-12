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
        velocityMultiplier = 5;
    }

    public void Forward()
    {
        horizontal = 0;
        vertical = 1;
        rigidBody.velocity = playerTransform.forward * vertical * velocityMultiplier;
    }

    public void Backward()
    {
        horizontal = 0;
        vertical = -1;
        rigidBody.velocity = playerTransform.forward * vertical * velocityMultiplier;
    }

    public void Left()
    {
        horizontal = -1;
        vertical = 0;
        rigidBody.velocity = playerTransform.right * horizontal * velocityMultiplier;
    }

    public void Right()
    {
        horizontal = 1;
        vertical = 0;
        rigidBody.velocity = playerTransform.right * horizontal * velocityMultiplier;
    }
}
