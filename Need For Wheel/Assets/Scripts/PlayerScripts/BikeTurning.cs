using UnityEngine;

// Turns the bike to be facing forward in the direction the player travels
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
        // When using LookRotaion an annoying console line is sent when the bike looks to Zero.
        // Therefor I check the velocity and calls Quaternion.identity if it gets to zero.
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
