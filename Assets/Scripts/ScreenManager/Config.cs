using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    [SerializeField] Transform _mainGame;

    void Start()
    {
        ScreenManager.Instance.Push(new ScreenGameObjects(_mainGame));
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !ScreenManager.Instance.isPaused)
        {
            ScreenManager.Instance.isPaused = true;
            var screenPause = Instantiate(Resources.Load<ScreenPause>("Canvas_Pause"));
            ScreenManager.Instance.Push(screenPause);
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScreenManager.Instance.Pop();
            Time.timeScale = 1f;
            ScreenManager.Instance.isPaused = false;
        }
    
    }
}
