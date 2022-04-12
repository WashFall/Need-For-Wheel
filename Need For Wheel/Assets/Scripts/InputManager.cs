using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerController player;

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

        Steering steering = new Steering();
        steering.Ground.Enable();
        steering.Ground.Steering.performed += Moving;
    }

    private void Moving(InputAction.CallbackContext context)
    {
        print(context);
        float direction = context.ReadValue<float>();

        if (direction == 1)
            right_command.Execute(player);
        else if(direction == -1)
            left_command.Execute(player);
    }
}
