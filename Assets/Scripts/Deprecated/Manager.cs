using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [SerializeField] private int _enemysToKillInWave;
    [SerializeField] private int _waves;
    [SerializeField] private int _level;
    [SerializeField] AudioClip _doorSFX;

    AudioSource _myAudioSource;
    AdditiveSceneLoader loader;
    SpawnEnemies spawner;

    //public Transform door;
    public Animation doorAnim;
    bool doorIsOpen = false;

    [SerializeField] private int _currentWave = 1;
    [SerializeField] private int currentEnemies;

    HealthManager player;
    CameraController cam;
    private float _health;

    private void Awake()
    {
        spawner = GetComponent<SpawnEnemies>();

    }

    private void Start()
    {
        loader = FindObjectOfType<AdditiveSceneLoader>();
        player = FindObjectOfType<HealthManager>();
        cam = FindObjectOfType<CameraController>();
        _myAudioSource = GetComponent<AudioSource>();
        spawner.Spawn(_enemysToKillInWave);
        currentEnemies = _enemysToKillInWave;
        _currentWave = 1;

    }



    private void Update()
    {
        if (currentEnemies == 0)
        {
            if(_currentWave == _waves)
            {
                OpenDoor();
                doorIsOpen = true;
                //loader.AllEnemiesKilled();
            }
            else
            {
                _currentWave++;
                currentEnemies = _enemysToKillInWave;
                new WaitForSeconds(100f);
                spawner.Spawn(_enemysToKillInWave);
            }
            
        }


        _health = player.getHealth();
        
        if(_health <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            if(_level >= 2)
            {
                SceneManager.LoadScene("Victory");
            }
            loader.AllEnemiesKilled();
            Debug.Log("nueva zona");
            GetComponent<BoxCollider>().enabled = false;
            cam.minPos.z = 25f;
            currentEnemies = _enemysToKillInWave;
            _currentWave = 1;
            Destroy(this.gameObject);
        }
    }

    public void EnemyDown()
    {
        currentEnemies--;
    }


    public int getCurrentWave()
    {
        return _currentWave;
    }

    public int getWaves()
    {
        return _waves;
    }

    public int GetLevel()
    {
        return _level;
    }

    public void OpenDoor()
    {
       
        if (doorIsOpen == false)
        {
            doorAnim.Play();
            _myAudioSource.Play();
        }

    }

}
