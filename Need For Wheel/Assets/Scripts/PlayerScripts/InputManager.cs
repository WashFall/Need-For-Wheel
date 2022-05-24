using System;
using UnityEngine;
using UnityEngine.InputSystem;

// Handles (mostly) all inputs from the player
// Keyboard and mouse, controller and phone (accelerometer)
// Also sends the commands for movement based on what the input vector says
public class InputManager : MonoBehaviour
{
    public bool invertControls;
    public float driftSpeed = 12;
    public PlayerController player;
    public BoostSystem boost = new BoostSystem();

    [HideInInspector]
    public Steering steering;

    private float drifting;
    private bool mobile;
    private Animator animator;
    private Accelerometer acc;
    private Touchscreen touch;
    private ICommand driveLeft_command;
    private ICommand driveRight_command;
    private ICommand driveForward_command;
    private ICommand driveBackward_command;
    private Quaternion correctionQuaternion;

    private void Awake()
    {
        driveLeft_command = new DriveLeft();
        driveRight_command = new DriveRight();
        driveForward_command = new DriveForward();
        driveBackward_command = new DriveBackward();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        if(SystemInfo.supportsAccelerometer)
            InputSystem.EnableDevice(Accelerometer.current);
        acc = Accelerometer.current;
        mobile = (acc != null);

        steering = new Steering(); // Using the new Input system
        steering.Ground.Enable();
        steering.Ground.LeftRight.canceled += ResetDirection;
        steering.Ground.ForwardBack.canceled += ResetDirection;
        steering.Ground.Drift.canceled += ResetDirection;
        steering.Ground.Drift.performed += context => { ServiceLocator.sound.PlayOnce("tires"); };
    }

    private void FixedUpdate()
    {
        if(PlayerController.State == PlayerState.Driving)
        {
            Vector3 direction;
            if (!mobile)
                direction = new Vector3(steering.Ground.LeftRight.ReadValue<float>(), 0, steering.Ground.ForwardBack.ReadValue<float>());
            else
            {
                float dirX = Accelerometer.current.acceleration.y.ReadValue();
                dirX *= -1;
                direction = new Vector3(Mathf.Clamp(dirX, -1, 1), 0, 0);
            }

            if (!mobile)
                drifting = steering.Ground.Drift.ReadValue<float>();
            else
                drifting = steering.Ground.Mobile.ReadValue<float>();

            if (direction.x > 0)
            {
                Vector3 inputVector = new Vector3(direction.x, 0, 0);
                driveRight_command.Execute(player, inputVector);
            }

            if (direction.x < 0)
            {
                Vector3 inputVector = new Vector3(direction.x, 0, 0);
                driveLeft_command.Execute(player, inputVector);
            }

            if (direction.z < 0)
            {
                Vector3 inputVector = new Vector3(0, 0, direction.z);
                driveBackward_command.Execute(player, inputVector);
                player.sidewayVelocityMultiplier = driftSpeed;
            }
            else if(drifting < 0)
            {
                Vector3 inputVector = new Vector3(0, 0, drifting);
                driveBackward_command.Execute (player, inputVector);
                player.sidewayVelocityMultiplier = driftSpeed;
            }

            if (direction.z == 0)
            {
                player.sidewayVelocityMultiplier = 8;
            }

            if (player.autoForward)
            {
                Vector3 inputVector = new Vector3(0, 0, 1);
                driveForward_command.Execute(player, inputVector);
            }
            else if(!player.autoForward && direction.z > 0)
            {
                Vector3 inputVector = new Vector3(0, 0, direction.z);
                driveForward_command.Execute(player, inputVector);
            }

            // Changes the animation based on if the player is drifting or not
            if(direction.z < 0 && direction.x > 0 || drifting < 0 && direction.x > 0)
            {
                animator.SetBool("DriftRight", true);
            }
            else
            {
                animator.SetBool("DriftRight", false);
            }

            if(direction.z < 0 && direction.x < 0 || drifting < 0 && direction.x < 0)
            {
                animator.SetBool("DriftLeft", true);
            }
            else
            {
                animator.SetBool("DriftLeft", false);
            }
        }
        else if(PlayerController.State == PlayerState.Flying)
        {
            Vector3 direction;
            if(!mobile)
                direction = new Vector3(steering.Ground.LeftRight.ReadValue<float>(), steering.Ground.ForwardBack.ReadValue<float>(), 0);
            else
            {
                float dirX = Accelerometer.current.acceleration.y.ReadValue();
                dirX *= -1;
                direction = new Vector3(Mathf.Clamp(dirX, -1, 1), 0, 0);
            }
            if (invertControls)
            {
                direction.y *= -1;
            }

            // Limits the player from rising in flight mode if there is no boost left
            if(BoostSystem.boost > 0 && !boost.outOfBoost)
            {
                float flight;
                if (mobile)
                    flight = steering.Ground.Mobile.ReadValue<float>() * -1;
                else
                    flight = direction.y;

                if (flight > 0)
                {
                    Vector3 inputVector = new Vector3(0, flight, 0);
                    driveForward_command.Execute(player, inputVector);
                    boost.BoostDown();
                }
            }

            if(direction.y < 0)
            {
                Vector3 inputVector = new Vector3(0, direction.y, 0);
                driveBackward_command.Execute(player, inputVector);
            }

            if (direction.x > 0)
            {
                Vector3 inputVector = new Vector3(direction.x, 0, 0);
                driveRight_command.Execute(player, inputVector);
            }

            if (direction.x < 0)
            {
                Vector3 inputVector = new Vector3(direction.x, 0, 0);
                driveLeft_command.Execute(player, inputVector);
            }
        }

        if (player.increaseGravity)
            player.Gravity();

        boost.BoostUp(player.rigidBody.position.z - PointSystem.startingPoint);
    }

    // Resets the direction the player is travelling in if the inputs are let go of
    // This is to prevent the player from travelling to the edges if no input is given
    private void ResetDirection(InputAction.CallbackContext context)
    {
        Vector3 direction = new Vector3(steering.Ground.LeftRight.ReadValue<float>(), 0, steering.Ground.ForwardBack.ReadValue<float>());

        if(direction.x == 0)
        {
            driveRight_command.Execute(player, direction);
            driveLeft_command.Execute(player, direction);
        }

        if(direction.z == 0)
        {
            direction.z = 0;
            driveForward_command.Execute(player, direction);
            driveBackward_command.Execute(player, direction);
        }
    }
}
