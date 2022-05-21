using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDestination : MonoBehaviour
{
    public Transform slope;
    public Transform plane;
    public float segmentLength;
    
    public void RotateSlope(float degrees)
    {
        slope.rotation = Quaternion.Euler(degrees, 0f, 0f);
        var shift = -segmentLength * Mathf.Sin(degrees * Mathf.Deg2Rad);
        slope.position += new Vector3(0f, shift * 0.5f, 0f);
        plane.position += new Vector3(0f, shift, 0f);
    }
}
