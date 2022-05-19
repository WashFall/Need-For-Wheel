using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineCollider : MonoBehaviour
{
    public bool collideOnce;

    private GameObject canvas;

    private void Start()
    {
        canvas = this.gameObject.transform.GetChild(0).gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player" && !collideOnce)
        {
            collideOnce = true;
            collision.transform.GetComponent<PlayerController>().dead = true;
            PlayerController.State = PlayerState.Dead;
            collision.gameObject.GetComponent<InputManager>().steering.Ground.Disable();
            canvas.SetActive(true);
            PointSystem.points *= 1.5f;
            PointSystem.points = Mathf.Round(PointSystem.points);
        }
    }
}
