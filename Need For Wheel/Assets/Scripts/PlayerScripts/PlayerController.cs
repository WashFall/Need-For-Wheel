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

    private void Awake()
    {
        dead = false;
        State = PlayerState.Driving;
        rigidBody = GetComponent<Rigidbody>();
        controls = GetComponent<DrivingControls>();
    }

    private void Update()
    {
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

    private void GroundedCheck()
    {
        RaycastHit hit;
        Physics.Raycast(rigidBody.position, Vector3.down, out hit, 1);
        if(hit.collider != null)
            grounded = true;
        else
            grounded = false;
    }

    public void GravitySwitch()
    {
        increaseGravity = increaseGravity ? false : true;
    }

    public void Gravity()
    {
        rigidBody.AddRelativeForce(new Vector3(0, gravityIncrease, 0), ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "BrickWall")
        {
            ServiceLocator.sound.PlayOnce("car crash");
            BoostSystem.boost -= 5;
        }
    }
}
