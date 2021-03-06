using UnityEngine;

public interface ICommand // The command interface for the movement inputs
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
