using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CheaterConsole : MonoBehaviour
{
    [SerializeField]
    public static GameObject Player;

    private UIDocument _root;

    private TextField _textField;

    private ScrollView _scrollView;

    public void Start()
    {
        _root = GetComponent<UIDocument>();
        _textField = _root.rootVisualElement.Q<TextField>("textfield");
        _scrollView = _root.rootVisualElement.Q<ScrollView>("scrollview");

        _textField.RegisterCallback<KeyDownEvent>((e) => EventHandler(e));
    }

    public void EventHandler(KeyDownEvent e) { 
        switch (e.keyCode)
        {
            case KeyCode.Return:
                Debug.Log($"{_textField.value}");
                ICommand command = CommandManager.MakeCommand(_textField.value);

                if (command == null)
                    return;

                MakeLabel(_textField.value);
                _textField.value = "";
                command.Execute();
                break;
        }
    }

    private void MakeLabel(string value)
    {
        Label label = new();
        label.text = value;

        _scrollView.hierarchy.Add(label);
    }

  
}
