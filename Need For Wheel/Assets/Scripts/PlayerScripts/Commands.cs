using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute(PlayerController player, Vector3 inputVector);
}

public class MoveLeft : ICommand
{
    public void Execute(PlayerController player, Vector3 inputVector)
    {
        player.Left(inputVector);
    }
}

public class MoveRight : ICommand
{
    public void Execute(PlayerController player, Vector3 inputVector)
    {
        player.Right(inputVector);
    }
}

public class MoveForward : ICommand
{
    public void Execute(PlayerController player, Vector3 inputVector)
    {
        player.Forward(inputVector);
    }
}

public class MoveBackward : ICommand
{
    public void Execute(PlayerController player, Vector3 inputVector)
    {
        player.Backward(inputVector);
    }
}
public class MoveUp : ICommand
{
    public void Execute(PlayerController player, Vector3 inputVector)
    {
        player.Rise(inputVector);
    }
}
