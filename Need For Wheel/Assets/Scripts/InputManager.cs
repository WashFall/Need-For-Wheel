using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public bool flying;
    public PlayerController player;

    [HideInInspector]
    public Steering steering;

    private ICommand up_command;
    private ICommand left_command;
    private ICommand right_command;
    private PlayerInput playerInput;
    private ICommand forward_command;
    private ICommand backward_command;

    private void Awake()
    {
        up_command = new MoveUp();
        left_command = new MoveLeft();
        right_command = new MoveRight();
        forward_command = new MoveForward();
        backward_command = new MoveBackward();
    }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        steering = new Steering();
        steering.Ground.Enable();
        steering.Ground.LeftRight.canceled += ResetDirection;
        steering.Ground.ForwardBack.canceled += ResetDirection;
    }

    private void FixedUpdate()
    {
        Vector3 direction;
        if (!flying)
            direction = new Vector3(steering.Ground.LeftRight.ReadValue<float>(), 0, steering.Ground.ForwardBack.ReadValue<float>());
        else
            direction = new Vector3(steering.Ground.LeftRight.ReadValue<float>(), steering.Ground.ForwardBack.ReadValue<float>(), 0);

        if (direction.x > 0)
        {
            Vector3 inputVector = new Vector3(direction.x, 0, 0);
            right_command.Execute(player, inputVector);
        }

        if (direction.x < 0)
        {
            Vector3 inputVector = new Vector3(direction.x, 0, 0);
            left_command.Execute(player, inputVector);
        }

        if (direction.z < 0)
        {
            Vector3 inputVector = new Vector3(0, 0, direction.z);
            backward_command.Execute(player, inputVector);
        }

        if (player.autoForward)
        {
            Vector3 inputVector = new Vector3(0, 0, 1);
            forward_command.Execute(player, inputVector);
        }
        else if(!player.autoForward && direction.z > 0)
        {
            Vector3 inputVector = new Vector3(0, 0, direction.z);
            forward_command.Execute(player, inputVector);
        }

        if(flying && direction.y > 0)
        {
            Vector3 inputVector = new Vector3(0, direction.y, 0);
            up_command.Execute(player, inputVector);
        }

    }

    private void ResetDirection(InputAction.CallbackContext context)
    {
        Vector3 direction = new Vector3(steering.Ground.LeftRight.ReadValue<float>(), 0, steering.Ground.ForwardBack.ReadValue<float>());

        if(direction.x == 0)
        {
            right_command.Execute(player, direction);
            left_command.Execute(player, direction);
        }

        if(direction.z == 0)
        {
            direction.z = 0;
            forward_command.Execute(player, direction);
            backward_command.Execute(player, direction);
        }
    }

    //private void Moving(InputAction.CallbackContext context)
    //{
    //    print(context);
    //    Vector2 direction = context.ReadValue<Vector2>();

    //    if (direction.x > 0)
    //        right_command.Execute(player);
    //    else if(direction.x < 0)
    //        left_command.Execute(player);

    //    if(direction.y > 0)
    //        up_command.Execute(player);
    //    else if(direction.y < 0)
    //        down_command.Execute(player);
    //}
}
