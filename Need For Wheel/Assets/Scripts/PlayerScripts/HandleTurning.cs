using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTurning : MonoBehaviour
{
    public GameObject player;

    private Rigidbody rb;
    private Quaternion quat;
    private InputManager inputManager;

    private void Start()
    {
        quat = transform.localRotation;
        rb = player.GetComponent<Rigidbody>();
        inputManager = player.GetComponent<InputManager>();
    }

    private void Update()
    {
        //transform.localRotation = new Quaternion(quat.x, quat.y, quat.z , quat.w);
    }
}
