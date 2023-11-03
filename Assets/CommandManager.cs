using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager 
{

    public static ICommand MakeCommand(string command)
    {
        command.ToLower();

        string[] commands = command.Split(' ');

        Debug.Log(commands);

        return command switch
        {
            "speed" => new SpeedCommand((float) Convert.ToDouble(commands[1])),
            _ => null,
        };
    }

}
