using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerController player;
    private Steering steering;

    private ICommand up_command;
    private ICommand down_command;
    private ICommand left_command;
    private ICommand right_command;

    private void Awake()
    {
        up_command = new MoveForward();
        down_command = new MoveBackward();
        left_command = new MoveLeft();
        right_command = new MoveRight();
    }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        steering = new Steering();
        steering.Ground.Enable();
        
        steering.Ground.Testmap.canceled += ResetDirection;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (Vector3)steering.Ground.Testmap.ReadValue<Vector2>();
        //print(direction);
        direction.z = direction.y;
        direction.y = 0;

        if (direction.x > 0)
        {
            //direction.z = 0;
            right_command.Execute(player, direction);
        }
        else if (direction.x < 0)
        {
            //direction.z = 0;
            left_command.Execute(player, direction);
        }

        if (direction.z < 0)
        {
            //direction.x = 0;
            down_command.Execute(player, direction);
        }

        if (player.autoForward)
        {
            direction.x = 0;
            up_command.Execute(player, direction);
        }
        else if(!player.autoForward && direction.z > 0)
        {
            //direction.x = 0;
            up_command.Execute(player, direction);
        }
    }

    private void ResetDirection(InputAction.CallbackContext context)
    {
        Vector3 direction = (Vector3)context.ReadValue<Vector2>();
        print("hej");

        if(direction.x == 0)
        {
            right_command.Execute(player, direction);
            left_command.Execute(player, direction);
        }

        if(direction.y == 0)
        {
            direction.z = direction.y;
            direction.y = 0;
            up_command.Execute(player, direction);
            up_command.Execute(player, direction);
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
