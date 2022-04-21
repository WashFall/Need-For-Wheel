using UnityEngine;
using System.Collections;

public class QuickCameraFollow : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if(!player.GetComponent<PlayerController>().dead)
            transform.position = player.transform.position + offset;
    }
}