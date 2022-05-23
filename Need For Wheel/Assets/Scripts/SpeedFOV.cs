using UnityEngine;

public class SpeedFOV : MonoBehaviour
{
    public Camera cam;
    public Rigidbody body;
    public float maxSpeed;
    public float minimumFOV;
    public float maximumFOV;

    void Update()
    {
        float currentSpeed = body.velocity.magnitude;
        float speedPercentage = currentSpeed / maxSpeed;
        float targetFOV = Mathf.Lerp(minimumFOV, maximumFOV, speedPercentage);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, Time.deltaTime);
    }
}
