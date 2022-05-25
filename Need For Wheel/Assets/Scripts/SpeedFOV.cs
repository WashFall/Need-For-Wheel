using UnityEngine;

public class SpeedFOV : MonoBehaviour
{
    public Camera cam;
    public Rigidbody body;
    public float maxSpeed;
    public float minimumFOV;
    public float maximumFOV;

    // Adjusts the field of view of the camera based on player speed
    void Update()
    {
        float currentSpeed = body.velocity.magnitude;
        float speedPercentage = currentSpeed / maxSpeed;
        float targetFOV = Mathf.Lerp(minimumFOV, maximumFOV, speedPercentage);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, Time.deltaTime);
    }
}
