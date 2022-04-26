using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeTurning : MonoBehaviour
{
    public GameObject player;

    private Rigidbody rb;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(rb.velocity);
    }
}
