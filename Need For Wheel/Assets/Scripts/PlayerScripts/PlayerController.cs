using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool dead;
    public bool noForward;
    public bool autoForward;
    public Controls controls;
    public Rigidbody rigidBody;
    public bool increaseGravity;
    public float gravityIncrease;
    public float sidewayVelocityMultiplier = 5;
    public float forwardVelocityMultiplier = 10;
    public static PlayerState State = new PlayerState();

    private void Awake()
    {
        dead = false;
        State = PlayerState.Driving;
        rigidBody = GetComponent<Rigidbody>();
        controls = GetComponent<DrivingControls>();
    }

    private void Update()
    {
        if(State == PlayerState.Flying)
        {
            controls = GetComponent<FlyingControls>();
            increaseGravity = false;
            rigidBody.drag = 0.1f;
        }
    }

    public void GravitySwitch()
    {
        increaseGravity = increaseGravity ? false : true;
    }

    public void Gravity()
    {
        rigidBody.AddRelativeForce(new Vector3(0, gravityIncrease, 0), ForceMode.Acceleration);
    }
}
