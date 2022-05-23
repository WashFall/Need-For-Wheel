using UnityEngine;

public class HandleTurning : MonoBehaviour
{
    public GameObject player;

    private Rigidbody rb;
    private Quaternion quat;
    private InputManager inputManager;

    private void Start()
    {
        quat = transform.localRotation;
        rb = player.GetComponent<Rigidbody>();
        inputManager = player.GetComponent<InputManager>();
    }
}
