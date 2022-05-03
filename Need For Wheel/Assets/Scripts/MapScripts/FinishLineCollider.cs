using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineCollider : MonoBehaviour
{
    private GameObject canvas;

    private void Start()
    {
        canvas = this.gameObject.transform.GetChild(0).gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PlayerController>().dead = true;
            collision.gameObject.GetComponent<InputManager>().steering.Ground.Disable();
            canvas.SetActive(true);
        }
    }
}
