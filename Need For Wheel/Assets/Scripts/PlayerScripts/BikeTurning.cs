using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeTurning : MonoBehaviour
{
    public GameObject player;
    public Transform bike;

    private Rigidbody rb;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //if(PlayerController.State == PlayerState.Driving)
            bike.rotation = rb.velocity == Vector3.zero ? Quaternion.identity : Quaternion.LookRotation(rb.velocity);
        
    }
}
