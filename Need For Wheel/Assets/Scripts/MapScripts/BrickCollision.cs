using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject parent;

    private Vector3 pos;
    private GameObject crashObject;
    private bool hasCrashed = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerTrigger")
        {
            hasCrashed = true;
            crashObject = other.gameObject;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void Start()
    {
        pos = transform.position;
    }

    private void Update()
    {
        if (hasCrashed)
        {
            if(pos.z < crashObject.transform.position.z - 20)
            {
                Destroy(parent);
            }
        }
    }
}
