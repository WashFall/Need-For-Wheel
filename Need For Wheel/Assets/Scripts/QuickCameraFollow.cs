using UnityEngine;
using System.Collections;
using System;

public class QuickCameraFollow : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    private Vector3 offsetChange;
    private Vector3 position;
    private bool stateChanged;

    void Start()
    {
        offset = transform.position - player.transform.position;
        stateChanged = false;
    }

    private void Update()
    {
        if(PlayerController.State == PlayerState.Flying)
        {
            if(!stateChanged)
                StateChanged();
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, 10 * Time.deltaTime);
            offset = Vector3.Lerp(offset, offsetChange, 7 * Time.deltaTime);
        }
    }

    private void StateChanged()
    {
        offsetChange += new Vector3(offset.x, offset.y - 3, offset.z - 7);
        stateChanged = true;
    }

    void LateUpdate()
    {
        if(!player.GetComponent<PlayerController>().dead)
            transform.position = player.transform.position + offset;
    }
}