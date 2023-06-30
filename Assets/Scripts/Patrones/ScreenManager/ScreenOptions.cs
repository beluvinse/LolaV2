using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenOptions : MonoBehaviour, IScreen
{
    Button[] _buttons;


    void Awake()
    {
        _buttons = GetComponentsInChildren<Button>();

        ActivateButtons(false);
    }

    public void BTN_Back()
    {
        ScreenManager.Instance.Pop();
        ScreenManager.Instance.Push("Canvas_Pause");
    }


    void ActivateButtons(bool enable)
    {
        foreach (var button in _buttons)
        {
            button.interactable = enable;
        }
    }

    public void Activate()
    {
        ActivateButtons(true);
    }

    public void Deactivate()
    {
        ActivateButtons(false);
    }

    public void Free()
    {
        Destroy(gameObject);
    }


}