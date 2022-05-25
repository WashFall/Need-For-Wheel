using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool dead;
    public bool grounded;
    public bool noForward;
    public bool autoForward;
    public Controls controls;
    public GameObject glider;
    public Rigidbody rigidBody;
    public bool increaseGravity;
    public float gravityIncrease;
    public float sidewayVelocityMultiplier = 8;
    public float forwardVelocityMultiplier = 9;
    public static PlayerState State = new PlayerState();

    private float refreshTime;
    private float oldTime;

    private void Awake()
    {
        dead = false;
        State = PlayerState.Driving;
        rigidBody = GetComponent<Rigidbody>();
        controls = GetComponent<DrivingControls>();
        oldTime = Time.time;
    }

    private void Update()
    {
        // Changes a few settings when the player is airborn
        if(State == PlayerState.Flying)
        {
            rigidBody.drag = 0.1f;
            increaseGravity = false;
            glider.gameObject.SetActive(true);
            rigidBody.rotation = Quaternion.identity;
            controls = GetComponent<FlyingControls>();
        }
        GroundedCheck();
    }

    // Checks if the player is on the ground
    private void GroundedCheck()
    {
        RaycastHit hit;
        Physics.Raycast(rigidBody.position, Vector3.down, out hit, 1);
        if(hit.collider != null)
            grounded = true;
        else
            grounded = false;
    }

    // Increases gravity
    public void GravitySwitch()
    {
        increaseGravity = increaseGravity ? false : true;
    }

    public void Gravity()
    {
        rigidBody.AddRelativeForce(new Vector3(0, gravityIncrease, 0), ForceMode.Acceleration);
    }

    // Plays a sound when player collides with a brick wall
    // The timers are to prevent the sound being played five or more times per collision
    private void OnTriggerEnter(Collider other)
    {
        refreshTime = Time.time;

        if(refreshTime - oldTime > 0.75f)
        {
            if(other.tag == "BrickWall")
            {
                ServiceLocator.sound.PlayOnce("car crash");
                BoostSystem.boost -= 5;
                oldTime = Time.time;
            }
        }
    }
}
