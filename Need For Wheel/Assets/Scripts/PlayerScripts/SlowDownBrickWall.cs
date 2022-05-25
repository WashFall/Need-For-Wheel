using UnityEngine;

// Slowing the player down before colliding with a brick wall
public class SlowDownBrickWall : MonoBehaviour
{
    public Rigidbody player;

    private float speedDown = 0.85f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BrickWall") player.velocity *= speedDown;
    }
}
