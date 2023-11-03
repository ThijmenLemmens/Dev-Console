using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GlobalUIControls : MonoBehaviour
{

    private UIDocument _root;

    private bool _isUIVisible = true;

    void Start()
    {
        _root = GetComponent<UIDocument>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            _isUIVisible = !_isUIVisible;
            _root.rootVisualElement.style.display = _root ? DisplayStyle.Flex : DisplayStyle.None;
        }
    }
}
