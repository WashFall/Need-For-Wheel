using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public bool flying;
    public float driftSpeed;
    public PlayerController player;

    [HideInInspector]
    public Steering steering;

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
    }

    private void Start()
    {
        steering = new Steering();
        steering.Ground.Enable();
        steering.Ground.LeftRight.canceled += ResetDirection;
        steering.Ground.ForwardBack.canceled += ResetDirection;
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

            if(direction.z == 0)
            {
                player.sidewayVelocityMultiplier = 5;
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
        }
        else if(PlayerController.State == PlayerState.Flying)
        {
            Vector3 direction;
            direction = new Vector3(steering.Ground.LeftRight.ReadValue<float>(), steering.Ground.ForwardBack.ReadValue<float>(), 0);

            if (direction.y > 0)
            {
                Vector3 inputVector = new Vector3(0, direction.y, 0);
                driveForward_command.Execute(player, inputVector);
            }

            if(direction.y < 0)
            {
                Vector3 inputVector = new Vector3(0, direction.y, 0);
                driveBackward_command.Execute(player, inputVector);
            }
        }


        if (player.increaseGravity)
            player.Gravity();
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
