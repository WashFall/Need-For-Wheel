using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool dead;
    public bool grounded;
    public bool noForward;
    public bool autoForward;
    public Controls controls;
    public Rigidbody rigidBody;
    public bool increaseGravity;
    public float gravityIncrease;
    public float sidewayVelocityMultiplier = 8;
    public float forwardVelocityMultiplier = 9;
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
            rigidBody.rotation = Quaternion.identity;
        }
        GroundedCheck();
    }

    private void GroundedCheck()
    {
        RaycastHit hit;
        Physics.Raycast(rigidBody.position, Vector3.down, out hit, 1);
        if(hit.collider != null)
            grounded = true;
        else
            grounded = false;
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
