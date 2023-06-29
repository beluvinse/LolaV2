using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBuilder
{
    Enemy _enemy;

    Vector3 _selectedPos;


    public EnemyBuilder(Enemy e)
    {
        _enemy = e;
    }

    public EnemyBuilder SetPosition(Vector3 value)
    {
        Debug.Log(value);
        _selectedPos = value;
        return this;
    }

    public EnemyBuilder SetPosition(float x, float y, float z)
    {
        _selectedPos = new Vector3(x, y, z);
        return this;
    }
    

    public Enemy Done()
    {
        Enemy enemyCreated = GameObject.Instantiate(_enemy);

        enemyCreated.transform.position = _selectedPos;

        enemyCreated.GetComponent<NavMeshAgent>().enabled = true;
        return enemyCreated;
    }
}
