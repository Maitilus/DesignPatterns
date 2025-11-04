using JetBrains.Annotations;
using UnityEngine;

public class DashCommand : ICommand
{
    PlayerController _playerController;
    public DashCommand(PlayerController playerController)
    {
        _playerController = playerController;
    }
    public void Execute()
    {
        _playerController.PerformDashPhysics();
    }
}
