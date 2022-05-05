using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public GameObject player;
    public Text pointsDisplay;
    public static float points;
    public static float startingPoint;

    private Rigidbody rb;
    private float oldPosition;
    private float newPosition;

    private void Start()
    {
        points = 0;
        oldPosition = 0;
        rb = player.GetComponent<Rigidbody>();
        startingPoint = player.transform.position.z;
    }

    void FixedUpdate()
    {
        if (!player.GetComponent<PlayerController>().dead)
        {
            newPosition = player.transform.position.z - startingPoint - oldPosition;
            points += (newPosition) * (rb.velocity.z / 10);
            points = Mathf.Round(points);
            pointsDisplay.text = "POINTS: " + points.ToString();
            oldPosition = player.transform.position.z - startingPoint;
        }
    }
}
