using UnityEngine;
using TMPro;

public class SpeedDisplay : MonoBehaviour
{
    public Rigidbody player;
    public TMP_Text speedText;

    private float speed;

    void Update() // Updates the speed display on the UI to the players current velocity
    {
        speed = Mathf.Round(player.velocity.z);

        speedText.text = speed + " km/h";
    }
}
