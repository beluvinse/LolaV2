using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenPause : MonoBehaviour, IScreen
{
    Button[] _buttons;

    private void Awake()
    {
        _buttons = GetComponentsInChildren<Button>();

        ActivateButtons(false);
    }

    public void BTN_Options()
    {
        ScreenManager.Instance.Pop();
        ScreenManager.Instance.Push("Canvas_Options");
    }

    public void BTN_Back()
    {
        ScreenManager.Instance.Pop();
        Time.timeScale = 1f;
        ScreenManager.Instance.isPaused = false;
    }

    public void BTN_Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ScreenManager.Instance.isPaused = false;
    }

    public void BTN_ExitGame()
    {
        Application.Quit();
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
