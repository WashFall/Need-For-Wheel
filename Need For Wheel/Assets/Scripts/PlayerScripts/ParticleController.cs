using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject bike;
    public PlayerController player;
    public ParticleSystem dustLeft, dustRight;

    private Rigidbody playerRigid;

    private void Awake()
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

        if(playerRigid.velocity.z > 70)
        {
            leftEmission.rateOverTime = Mathf.Round(playerRigid.velocity.z) / 3;
            rightEmission.rateOverTime = Mathf.Round(playerRigid.velocity.z) / 3;
        }
        else
        {
            leftEmission.rateOverTime = 0;
            rightEmission.rateOverTime = 0;
        }
    }
}
