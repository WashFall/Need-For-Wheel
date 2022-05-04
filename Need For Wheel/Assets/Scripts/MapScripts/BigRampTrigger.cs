using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRampTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            PlayerController.State = PlayerState.Flying;
            collision.GetComponent<InputManager>().boost.SetBoost(Mathf.Round(PointSystem.points / 10));
        }
    }
}
