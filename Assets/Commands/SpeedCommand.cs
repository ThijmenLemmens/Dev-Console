using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCommand : ICommand
{

    private float _speed;

    public SpeedCommand(float speed)
    {
        _speed = speed;
    }

    public void Execute()
    {
        FPSplayer.moveSpeed = _speed;
    }
}
