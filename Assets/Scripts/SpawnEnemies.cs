using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private List<GameObject> _spawns;

    int r = 0;
    int level = 1;
    public Manager _manager;


    private void Start()
    {
        _manager = GetComponent<Manager>();
        r = Random.Range(0, 9);
        level = _manager.GetLevel();
    }

    public void Spawn(int cantEnemigos)
    {
        Debug.Log("a");
        Debug.Log(level);
        Debug.Log(_manager);
        switch (level)
        {
            case 1:
                {
                    for (int i = 0; i < cantEnemigos; i++)
                    {
                        if (r < 6)
                        {
                            Instantiate(_enemies[0], _spawns[i].transform.position, Quaternion.identity, _manager.transform);
                        }
                        else
                            Instantiate(_enemies[1], _spawns[i].transform.position, Quaternion.identity, _manager.transform);

                        r = Random.Range(0, 9);
                    }
                    break;

                }
            case 2:
                {
                    for (int i = 0; i< cantEnemigos; i++)
                    {
                        if(r < 4)
                        {
                            Instantiate(_enemies[0], _spawns[i].transform.position, Quaternion.identity, _manager.transform);
                        }
                        else if(r >= 4 && r <= 7)
                        {
                            Instantiate(_enemies[1], _spawns[i].transform.position, Quaternion.identity, _manager.transform);
                        }
                        else
                        {
                            Instantiate(_enemies[2], _spawns[i].transform.position, Quaternion.identity, _manager.transform);
                        }
                        r = Random.Range(0, 9);
                    }
                    break;
                }
        }

        
    }


    public List<GameObject> GetSpawns()
    {
        return _spawns;
    }
}
