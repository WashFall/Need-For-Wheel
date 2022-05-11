using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedFOV : MonoBehaviour
{
    public Camera cam;
    public Rigidbody body;
    public float minimumFOV;
    public float maximumFOV;

    public float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float currentSpeed = body.velocity.magnitude;
        float speedPercentage = currentSpeed / maxSpeed;
        float targetFOV = Mathf.Lerp(minimumFOV, maximumFOV, speedPercentage);

        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, Time.deltaTime);
    }
}
