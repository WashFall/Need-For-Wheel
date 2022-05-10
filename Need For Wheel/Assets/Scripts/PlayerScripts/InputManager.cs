using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public float driftSpeed = 12;
    public PlayerController player;
    public BoostSystem boost = new BoostSystem();

    [HideInInspector]
    public Steering steering;

    private Animator animator;

    private ICommand driveLeft_command;
    private ICommand driveRight_command;
    private ICommand driveForward_command;
    private ICommand driveBackward_command;

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
        steering = new Steering();
        steering.Ground.Enable();
        steering.Ground.LeftRight.canceled += ResetDirection;
        steering.Ground.ForwardBack.canceled += ResetDirection;

        ServiceLocator.SetAudioService(new NormalAudioService());
    }

    private void FixedUpdate()
    {
        if(PlayerController.State == PlayerState.Driving)
        {
            Vector3 direction;
            direction = new Vector3(steering.Ground.LeftRight.ReadValue<float>(), 0, steering.Ground.ForwardBack.ReadValue<float>());

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

            if(direction.z < 0 && direction.x > 0)
            {
                animator.SetBool("DriftRight", true);
            }
            else
            {
                animator.SetBool("DriftRight", false);
            }

            if(direction.z < 0 && direction.x < 0)
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
            direction = new Vector3(steering.Ground.LeftRight.ReadValue<float>(), steering.Ground.ForwardBack.ReadValue<float>(), 0);

            if(BoostSystem.boost > 0 && !boost.outOfBoost)
            {
                if (direction.y > 0)
                {
                    Vector3 inputVector = new Vector3(0, direction.y, 0);
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
