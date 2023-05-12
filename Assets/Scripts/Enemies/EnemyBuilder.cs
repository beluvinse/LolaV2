using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBuilder
{
    Enemy _enemy;

    Vector3 _selectedPos;
    Vector3 _selectedScale;
    float _selectedHP;
    float _selectedDmg;

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
    
    public EnemyBuilder SetScale(Vector3 value)
    {
        _selectedScale = value;
        return this;
    }
    
    public EnemyBuilder SetMaxLife(float value)
    {
        _selectedHP = value;
        return this;
    }
    
    public EnemyBuilder SetDamage(float value)
    {
        _selectedDmg = value;
        return this;
    }

    public Enemy Done()
    {
        Enemy enemyCreated = GameObject.Instantiate(_enemy);

        enemyCreated.transform.position = _selectedPos;

        enemyCreated.transform.localScale = _selectedScale;

        enemyCreated.MaxLife = _selectedHP;

        enemyCreated.Damage = _selectedDmg;

        enemyCreated.GetComponent<NavMeshAgent>().enabled = true;
        return enemyCreated;
    }
}
