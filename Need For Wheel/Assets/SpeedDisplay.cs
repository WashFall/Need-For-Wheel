using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedDisplay : MonoBehaviour
{
    public Rigidbody player;
    public Text speedText;

    private float speed;

    void Update()
    {
        speed = Mathf.Round(player.velocity.z);

        speedText.text = "SPEED: " + speed;
    }
}
