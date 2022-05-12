using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampagneGlassPowerup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<DrivingControls>().SpeedPowerUp();
            Destroy(gameObject);
        }
    }
}
