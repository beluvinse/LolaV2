using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
