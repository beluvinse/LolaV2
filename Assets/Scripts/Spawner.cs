using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> _spawns;
    [SerializeField] List<Enemy> _allEnemies;


    private void Awake()
    {
        foreach (GameObject spawn in _spawns)
        {
            Enemy enemy = new EnemyBuilder(_allEnemies[Random.Range(0, 3)])
                            .SetDamage(Random.Range(10, 30))
                            .SetPosition(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z)
                            .SetScale(Vector3.one)
                            .SetMaxLife(Random.Range(100, 200))
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
