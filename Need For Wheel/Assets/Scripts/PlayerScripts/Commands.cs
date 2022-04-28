using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute(PlayerController player, Vector3 inputVector);
}

public class DriveLeft : ICommand
{
    public void Execute(PlayerController player, Vector3 inputVector)
    {
        player.controls.Left(inputVector);
    }
}

public class DriveRight : ICommand
{
    public void Execute(PlayerController player, Vector3 inputVector)
    {
        player.controls.Right(inputVector);
    }
}

public class DriveForward : ICommand
{
    public void Execute(PlayerController player, Vector3 inputVector)
    {
        player.controls.Forward(inputVector);
    }
}

public class DriveBackward : ICommand
{
    public void Execute(PlayerController player, Vector3 inputVector)
    {
        player.controls.Backward(inputVector);
    }
}
