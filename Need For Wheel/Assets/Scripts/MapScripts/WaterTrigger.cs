using UnityEngine;

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
            canvas.SetActive(true);
            PlayerController.State = PlayerState.Dead;
            other.gameObject.GetComponent<PlayerController>().dead = true;
            other.gameObject.GetComponent<InputManager>().steering.Ground.Disable();
        }
    }
}
