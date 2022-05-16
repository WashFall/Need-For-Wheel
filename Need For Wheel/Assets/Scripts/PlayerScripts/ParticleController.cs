using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject bike;
    public PlayerController player;
    public ParticleSystem dustLeft, dustRight;

    private void Start()
    {

    }

    void Update()
    {
        IsGrounded();
    }

    private void IsGrounded()
    {
        if (player.grounded)
        {
            dustLeft.Play();
            dustRight.Play();
        }
        else
        {
            dustLeft.Stop();
            dustRight.Stop();
        }
    }
}
