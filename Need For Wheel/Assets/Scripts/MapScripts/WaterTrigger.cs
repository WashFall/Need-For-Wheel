using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterTrigger : MonoBehaviour
{
    private GameObject canvas;

    private void Start()
    {
        canvas = this.gameObject.transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<InputManager>().steering.Ground.Disable();
            other.gameObject.GetComponent<PlayerController>().dead = true;
            PlayerController.State = PlayerState.Dead;
            canvas.SetActive(true);
        }
    }
}
