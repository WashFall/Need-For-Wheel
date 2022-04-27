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
        bike.rotation = Quaternion.LookRotation(rb.velocity);
    }
}
