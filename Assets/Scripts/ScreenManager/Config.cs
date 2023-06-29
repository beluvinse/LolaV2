using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    bool gameIsPaused = false;

    [SerializeField] Transform _mainGame;

    void Start()
    {
        ScreenManager.Instance.Push(new ScreenGameObjects(_mainGame));
    }


    void Update()
    {
       /*if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameIsPaused)
            {
                var screenPause = Instantiate(Resources.Load<ScreenPause>("Canvas_Pause"));
                ScreenManager.Instance.Push(screenPause);
                gameIsPaused = true;
            }
            else
            {
                ScreenManager.Instance.Pop();
                gameIsPaused = false;
            }

        }*/

        if (Input.GetKeyDown(KeyCode.P))
        {
            var screenPause = Instantiate(Resources.Load<ScreenPause>("Canvas_Pause"));
            ScreenManager.Instance.Push(screenPause);
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScreenManager.Instance.Pop();
            Time.timeScale = 0f;
        }


    }
}
