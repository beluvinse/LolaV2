using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CommonZombie : Enemy
{
    public override void Attack()
    {
        if (_isAttacking)
        {
            attackCounter -= Time.fixedDeltaTime;
            if(attackCounter <= 0)
            {
                attackCounter = _attackDelay;
                _player.GetComponent<HealthManager>().TakeDamage(_damage);
                Debug.Log("te ataco");
            }
        }
        else
        {
            attackCounter -= Time.fixedDeltaTime;
        }
    }

   

}