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

    // Rotates the wheels around their center point relative to player velocity
    private void Update()
    {
        Vector3 position = GetComponentInChildren<MeshRenderer>().bounds.center;
        transform.RotateAround(position, transform.right, (rb.velocity.z * speed) * Time.deltaTime);
    }
}
