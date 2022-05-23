using UnityEngine;

public class QuickCameraFollow : MonoBehaviour
{
    public GameObject player;

    private bool finished;
    private Vector3 offset;
    private Vector3 position;
    private bool stateChanged;
    private Quaternion rotation;
    private Vector3 newPosition;
    private Vector3 offsetChange;

    void Start()
    {
        stateChanged = false;
        offset = transform.position - player.transform.position;
        rotation = transform.rotation;
    }

    // If the player enters a new state the camera should adjust itself accordingly
    private void Update()
    {
        if(PlayerController.State == PlayerState.Flying)
        {
            if(!stateChanged) StateChanged();

            transform.rotation = Quaternion.Lerp(transform.rotation, 
                                 Quaternion.identity, 10 * Time.deltaTime);

            offset = Vector3.Lerp(offset, offsetChange, 7 * Time.deltaTime);
        }
        else if(PlayerController.State == PlayerState.Dead)
        {
            if (!stateChanged) StateChanged();
                
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 3 * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, newPosition, 3 * Time.deltaTime);
        }
    }

    private void StateChanged()
    {
        stateChanged = true;
        position = transform.position;
        offsetChange += new Vector3(offset.x, offset.y - 3, offset.z - 3);
        newPosition = new Vector3(position.x, position.y + 5, position.z - 5);
    }

    // Make the camera stop its movement when the player "dies"
    void LateUpdate()
    {
        if (!player.GetComponent<PlayerController>().dead)
        {
            transform.position = player.transform.position + offset;
        }
        else if(player.GetComponent<PlayerController>().dead && !finished)
        {
            stateChanged = false;
            finished = true;
        }
    }
}