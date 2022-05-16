using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject bike;
    public PlayerController player;
    public ParticleSystem dustLeft, dustRight;

    private Rigidbody playerRigid;

    private void Start()
    {
        playerRigid = player.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        IsGrounded();
        ParticleSpeed();
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

    private void ParticleSpeed()
    {
        var leftEmission = dustLeft.emission;
        var rightEmission = dustRight.emission;

        leftEmission.rateOverTime = Mathf.Round(playerRigid.velocity.z) / 2;
        rightEmission.rateOverTime = Mathf.Round(playerRigid.velocity.z) / 2;
    }
}
