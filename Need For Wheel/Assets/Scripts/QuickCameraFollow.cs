using UnityEngine;
using System.Collections;

public class QuickCameraFollow : MonoBehaviour
{
    public bool dead = false;
    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        if(!dead)
            transform.position = player.transform.position + offset;
    }
}