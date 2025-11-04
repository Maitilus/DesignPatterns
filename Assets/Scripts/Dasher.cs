using UnityEngine;

public class Dasher
{
    ICommand _onCommand;

    public Dasher(ICommand onCommand)
    {
        _onCommand = onCommand;
    }

    public void DoDash()
    {
        _onCommand.Execute();
    }
}
