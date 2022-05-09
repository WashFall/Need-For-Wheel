using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    public GameObject player;

    private Vector3 pos;
    private bool hasCrashed = false;
    private GameObject crashObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<Rigidbody>().isKinematic = false;
            crashObject = other.gameObject;
            hasCrashed = true;
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
                Destroy(gameObject);
            }
        }
    }
}
