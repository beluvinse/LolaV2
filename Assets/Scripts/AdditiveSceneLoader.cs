using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveSceneLoader : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    Manager gameManager;

    bool _isSceneLoaded;

    private void Start()
    {
        gameManager = FindObjectOfType<Manager>();
    }

    private void OpenDoor(AsyncOperation asyncOp)
    {
        gameManager.OpenDoor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isSceneLoaded) return;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
        asyncLoad.completed += OpenDoor;
        _isSceneLoaded = true;
    }

    public void AllEnemiesKilled()
    {
        if (_isSceneLoaded) return;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
        asyncLoad.completed += OpenDoor;
        _isSceneLoaded = true;


    }

}