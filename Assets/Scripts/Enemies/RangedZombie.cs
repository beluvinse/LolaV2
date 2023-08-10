using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedZombie : Enemy
{
    public GameObject bullet;
    public Transform pointToShoot;

    public AnimationClip attackAnim;

    private void FixedUpdate()
    {
        if(type == TypeOfEnemy.Boss)
            ChasePlayer(FlyweightPointer.Boss.chaseRadius, FlyweightPointer.Boss.attackRadius);
        else if(type == TypeOfEnemy.Ranged)
            ChasePlayer(_chaseRadius, _attackRadius);

    }

    public override void Attack()
    {
        //attackCounter = attackAnim(length);
        if (_isAttacking)
        {
            attackCounter -= Time.fixedDeltaTime;
            if (attackCounter <= 0)
            {
                if(type == TypeOfEnemy.Boss)
                {
                    var bala = AcidBulletFactory.Instance.GetObject();
                    bala.transform.position = pointToShoot.position;
                    bala.transform.rotation = pointToShoot.rotation;
                    var balaComp = bala.GetComponent<AcidZombieBullet>();
                    if (balaComp)
                        bala.GetComponent<Rigidbody>().velocity = pointToShoot.forward * balaComp.GetSpeed();
                    Debug.Log("attack");
                }
                else if(type == TypeOfEnemy.Ranged)
                {
                    var bala = ZombieBulletFactory.Instance.GetObject();
                    bala.transform.position = pointToShoot.position;
                    bala.transform.rotation = pointToShoot.rotation;
                    var balaComp = bala.GetComponent<ZombieBullet>();
                    if (balaComp)
                        bala.GetComponent<Rigidbody>().velocity = pointToShoot.forward * balaComp.GetSpeed();
                    Debug.Log("attack");
                }
                attackCounter = _attackDelay;
                /*var bala = Instantiate(bullet, pointToShoot.position, pointToShoot.rotation);*/
                
                
            }
        }
        else
        {
            attackCounter -= Time.fixedDeltaTime;
        }
    }

}
