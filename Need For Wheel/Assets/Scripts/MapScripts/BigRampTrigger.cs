using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRampTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.GetComponent<InputManager>().flying = true;
        PlayerController.State = PlayerState.Flying;
        //collision.gameObject.GetComponent<PlayerController>().controls = collision.gameObject.GetComponent<FlyingControls>();
    }
}
