using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute(PlayerController player);
}

public class MoveLeft : ICommand
{
    public void Execute(PlayerController player)
    {
        player.Left();
    }
}

public class MoveRight : ICommand
{
    public void Execute(PlayerController player)
    {
        player.Right();
    }
}

public class MoveForward : ICommand
{
    public void Execute(PlayerController player)
    {
        player.Forward();
    }
}

public class MoveBackward : ICommand
{
    public void Execute(PlayerController player)
    {
        player.Backward();
    }
}
