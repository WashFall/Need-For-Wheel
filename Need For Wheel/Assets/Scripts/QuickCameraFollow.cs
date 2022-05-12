using UnityEngine;
using System.Collections;
using System;

public class QuickCameraFollow : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    private Vector3 position;
    private bool stateChanged;
    private Vector3 offsetChange;

    void Start()
    {
        stateChanged = false;
        offset = transform.position - player.transform.position;
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
        stateChanged = true;
        offsetChange += new Vector3(offset.x, offset.y - 3, offset.z - 3);
    }

    void LateUpdate()
    {
        if(!player.GetComponent<PlayerController>().dead)
            transform.position = player.transform.position + offset;
    }
}