using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool dead;
    public bool tilt;
    public bool noForward;
    public bool autoForward;
    public Rigidbody rigidBody;
    public bool increaseGravity;
    public float gravityIncrease;
    public float sidewayVelocityMultiplier = 5;
    public float forwardVelocityMultiplier = 10;
    public Controls controls;
    public static PlayerState State = new PlayerState();

    private Vector3 rayOrigin;
    private Renderer rend;

    private void Awake()
    {
        dead = false;
        State = PlayerState.Driving;
        rend = GetComponent<Renderer>();
        controls = GetComponent<DrivingControls>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (tilt)
        {
            RaycastHit hit;
            rayOrigin = transform.position + transform.forward * (rend.bounds.size.z / 2);
            if (Physics.Raycast(rayOrigin, -(transform.up), out hit, 20, 5))
            {
                Quaternion newrot = Quaternion.LookRotation(Vector3.Cross(transform.right, hit.normal));
                transform.rotation = Quaternion.Lerp(transform.rotation, newrot, 10 * Time.deltaTime);
            }
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
