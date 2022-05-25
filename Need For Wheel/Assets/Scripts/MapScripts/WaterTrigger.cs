using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    public GameObject pointCanvas;

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
            pointCanvas.SetActive(false);
            PlayerController.State = PlayerState.Dead;
            other.gameObject.GetComponent<PlayerController>().dead = true;
            other.gameObject.GetComponent<InputManager>().steering.Ground.Disable();
        }
    }
}
