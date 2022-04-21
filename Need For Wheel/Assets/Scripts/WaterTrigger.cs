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
        other.gameObject.GetComponent<InputManager>().steering.Ground.Disable();
        Camera.main.GetComponent<QuickCameraFollow>().dead = true;
        canvas.SetActive(true);
    }
}
