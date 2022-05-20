using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedDisplay : MonoBehaviour
{
    public Rigidbody player;
    public TMP_Text speedText;

    private float speed;

    void Update()
    {
        speed = Mathf.Round(player.velocity.z);

        speedText.text = speed + " km/h";
    }
}
