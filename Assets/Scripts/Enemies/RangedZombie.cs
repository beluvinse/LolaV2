using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RangedZombie : Enemy
{
    public Transform player;
    private Animator _myAnim;

    [Header("Values")]
    [SerializeField] private float _chaseRadius;
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _attackDelay;
    [SerializeField] private bool _isAttacking;

    public GameObject bullet;
    public Transform pointToShoot;

    private float attackCounter;
    public AnimationClip attackAnim;

    private void Awake()
    {
        _myAnim = GetComponentInChildren<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerMovement>().transform;// cambiar
        _myAnim.SetBool("moving", false);
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        FollowPlayer();
        if (distance <= _chaseRadius && distance > _attackRadius)
        {
            _navMeshAgent.SetDestination(player.position);
            transform.LookAt(player);
            _isAttacking = false;
            _myAnim.SetBool("moving", true);
        }
        else if (distance <= _attackRadius)
        {
            _isAttacking = true;
            _myAnim.SetBool("moving", false);
            transform.LookAt(player);
            Attack();
        }
        else
        {
            _myAnim.SetBool("moving", false);
        }
    }

    public override void Attack()
    {
        //attackCounter = attackAnim(length);
        if (_isAttacking)
        {
            attackCounter -= Time.fixedDeltaTime;
            if (attackCounter <= 0)
            {
                if(type == TypeOfEnemy.RangedAcid)
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

    

    private void FollowPlayer()
    {
        if (_isAttacking) _navMeshAgent.isStopped = true;
        else _navMeshAgent.isStopped = false;
    }

}
