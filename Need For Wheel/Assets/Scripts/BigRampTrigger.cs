using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigRampTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<InputManager>().flying = true;
    }
}
