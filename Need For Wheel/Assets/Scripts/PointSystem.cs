using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{
    public GameObject player;
    public Text pointsDisplay;

    private Rigidbody rb;
    private float points;
    private float oldPosition;
    private float newPosition;
    private float startingPoint;

    private void Start()
    {
        startingPoint = 0 - player.transform.position.z;
        points = 0;
        rb = player.GetComponent<Rigidbody>();
        oldPosition = startingPoint;
    }

    void Update()
    {
        if (!player.GetComponent<PlayerController>().dead)
        {
            newPosition = player.transform.position.z - oldPosition;
            points += (newPosition) * (rb.velocity.z / 100);
            points = Mathf.Round(points);
            pointsDisplay.text = "POINTS: " + points.ToString();
            Debug.Log(rb.velocity);
            oldPosition = player.transform.position.z + startingPoint;
        }
    }
}
