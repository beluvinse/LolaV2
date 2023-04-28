using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinLose : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Prueba");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
