using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public GameObject player;
    public Text pointsDisplay;
    public static float points;

    private Rigidbody rb;
    private float oldPosition;
    private float newPosition;
    private float startingPoint;

    private void Start()
    {
        startingPoint = player.transform.position.z;
        points = 0;
        rb = player.GetComponent<Rigidbody>();
        oldPosition = 0;
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
