using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBuilder
{
    Enemy _enemy;

    Vector3 _selectedPos;

    bool _level4;

    float _chaseRadius;


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

    public EnemyBuilder SetLevel4(bool val)
    {
        _level4 = val;
        return this;
    }

    public EnemyBuilder SetChaseRadius(float rad)
    {
        _chaseRadius = rad;
        return this;
    }
    

    public Enemy Done()
    {
        Enemy enemyCreated = GameObject.Instantiate(_enemy);

        enemyCreated.transform.position = _selectedPos;
        enemyCreated.SetLevel4 = _level4;
        enemyCreated.SetChaseRadius = _chaseRadius;

        enemyCreated.GetComponent<NavMeshAgent>().enabled = true;
        return enemyCreated;
    }
}
