using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownBrickWall : MonoBehaviour
{
    public Rigidbody player;

    private float speedDown = 0.85f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BrickWall")
        {
            player.velocity *= speedDown;
        }
    }
}
