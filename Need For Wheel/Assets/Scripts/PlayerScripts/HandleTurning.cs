using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleTurning : MonoBehaviour
{
    public GameObject player;

    private Quaternion quat;
    private Rigidbody rb;
    private InputManager inputManager;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        inputManager = player.GetComponent<InputManager>();
        quat = transform.localRotation;
    }

    private void Update()
    {
        //transform.localRotation = new Quaternion(quat.x, quat.y, quat.z , quat.w);
    }
}
