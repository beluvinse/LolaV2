using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> _spawns;
    [SerializeField] List<Enemy> _allEnemies;
    [SerializeField] bool _level4;
    [SerializeField] float _chaseRadius;


    private void Awake()
    {
        foreach (GameObject spawn in _spawns)
        {
            Enemy enemy = new EnemyBuilder(_allEnemies[Random.Range(0, 2)])
                            .SetPosition(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z)
                            .SetLevel4(_level4)
                            .SetChaseRadius(_chaseRadius)
                            .Done();
        }

        /*Enemy enemy = new EnemyBuilder(_allEnemies[Random.Range(0, 3)])
                            .SetDamage(Random.Range(10, 30))
                            .SetPosition(_spawns[0].transform.position)
                            .SetScale(Vector3.one)
                            .SetMaxLife(Random.Range(100, 200))
                            .Done();*/
    }
}
