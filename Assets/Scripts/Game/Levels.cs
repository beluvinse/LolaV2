using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Levels : MonoBehaviour
{
    public static Levels Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
            SceneManager.LoadScene("Level 1");

        if (Input.GetKeyDown(KeyCode.F2))
            SceneManager.LoadScene("Level 2");

        if (Input.GetKeyDown(KeyCode.F3))
            SceneManager.LoadScene("Level 3");

        if (Input.GetKeyDown(KeyCode.F4))
            SceneManager.LoadScene("Level 4");
    }
}
