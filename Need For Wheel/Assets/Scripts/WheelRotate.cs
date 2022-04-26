using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour
{
    public GameObject player;

    private Rigidbody rb;
    private float speed = 10;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 position = GetComponentInChildren<Renderer>().bounds.center;

        transform.RotateAround(position, Vector3.right, (rb.velocity.z * speed) * Time.deltaTime);
    }
}
