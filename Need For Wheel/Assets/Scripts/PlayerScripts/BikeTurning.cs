using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeTurning : MonoBehaviour
{
    public Transform bike;
    public float turnSpeed;
    public GameObject player;

    private Rigidbody rb;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!player.GetComponent<PlayerController>().dead)
        {
            bike.rotation = Quaternion.Lerp(bike.rotation, 
            rb.velocity == Vector3.zero ? Quaternion.identity : Quaternion.LookRotation(rb.velocity), 
            turnSpeed * Time.deltaTime);
        }
        else
        {
            bike.rotation = Quaternion.identity;
        }
    }
}
