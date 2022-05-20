using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointSystem : MonoBehaviour
{
    public GameObject player;
    public TMP_Text pointsDisplay;
    public static float points;
    public static float startingPoint;

    private Rigidbody rb;
    private float oldPosition;
    private float newPosition;
    private float velDivide = 10;
    private bool multiplierActive = false;
    private float startTime;
    private float endTime;

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
            points += (newPosition) * (rb.velocity.z / velDivide);
            points = Mathf.Round(points);
            pointsDisplay.text = "P: " + points.ToString();
            oldPosition = player.transform.position.z - startingPoint;
        }
    }

    public void Multiplier()
    {
        startTime = Time.time;
        endTime = Time.time + 5;
        multiplierActive = true;
    }

    private void Update()
    {
        if (multiplierActive)
        {
            startTime = Time.time;
            if (startTime < endTime)
            {
                velDivide = 5;
            }
            else if (endTime < startTime)
            {
                velDivide = 10;
                multiplierActive = false;
            }
        }
    }
}
