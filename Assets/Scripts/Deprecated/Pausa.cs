using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject generalUI;

    public GameObject ajustesUI;
    public GameObject flechita;

    public bool getPausa()
    {
        return GameIsPaused;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused && ajustesUI.activeSelf == false)
            {
                Resume();
            }
            else if (GameIsPaused == false)
            {
                Pause();
            }
            else if (GameIsPaused && ajustesUI.activeSelf == true)
            {
                Atras();
            }

        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        //generalUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        //generalUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    public void Restart()
    {
        Resume();
        //Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void Ajustes()
    {
        pauseMenuUI.SetActive(false);
        ajustesUI.SetActive(true);

    }

    public void Atras()
    {
        pauseMenuUI.SetActive(true);
        ajustesUI.SetActive(false);

    }

    public void Exit()
    {
        Application.Quit();
    }


}
