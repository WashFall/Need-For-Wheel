using UnityEngine;

// Controls the dust particles from the two back wheels on the bike
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

    // Only plays if the player is on the ground
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

    // Changes the rate of the particles the faster the player travels
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
