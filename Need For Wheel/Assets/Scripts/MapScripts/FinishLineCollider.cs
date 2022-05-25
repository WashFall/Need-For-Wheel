using UnityEngine;

public class FinishLineCollider : MonoBehaviour
{
    public bool collideOnce;
    public GameObject pointCanvas;

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
            canvas.SetActive(true);
            PointSystem.points *= 1.5f;
            pointCanvas.SetActive(false);
            PlayerController.State = PlayerState.Dead;
            PointSystem.points = Mathf.Round(PointSystem.points);
            collision.transform.GetComponent<PlayerController>().dead = true;
            collision.gameObject.GetComponent<InputManager>().steering.Ground.Disable();
        }
    }
}
