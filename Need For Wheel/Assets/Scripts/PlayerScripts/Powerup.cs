using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("HIT!");
            other.GetComponent<DrivingControls>().SpeedPowerUp();
            Destroy(gameObject);
        }
    }
}
