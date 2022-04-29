using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLinePoints : MonoBehaviour
{
    public Text pointsDisplay;

    private float doublePoints;

    private void Update()
    {
        doublePoints = (PointSystem.points * 1.5f);
        doublePoints = Mathf.Round(doublePoints);
        pointsDisplay.text = "You Won!\nThis is your final score: " + doublePoints.ToString();
    }
}
