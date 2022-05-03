using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRampTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
            collision.gameObject.GetComponent<InputManager>().flying = true;

        PlayerController.State = PlayerState.Flying;
    }
}
