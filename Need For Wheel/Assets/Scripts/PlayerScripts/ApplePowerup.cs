using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePowerup : MonoBehaviour
{
    public PointSystem pointSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            pointSystem.Multiplier();
            Destroy(gameObject);
        }
    }
}
