using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public abstract class Enemy : MonoBehaviour
{

    [Header("Values")]
    [SerializeField] protected float _life;
    [SerializeField] protected float _damage;
    [SerializeField] protected TypeOfEnemy type;

    [SerializeField] protected Transform _player;

    [Header("Attack")]
    [SerializeField] protected float _chaseRadius;
    [SerializeField] protected float _attackRadius;
    [SerializeField] protected float _attackDelay;
    [SerializeField] protected bool _isAttacking;
    [SerializeField] protected bool _level4;
    public bool SetLevel4 { set { _level4 = value; } }
    public float SetChaseRadius { set { _chaseRadius = value; } }



    private Animator _myAnim;

    private AudioSource _myAudioSource;

    protected NavMeshAgent _navMeshAgent;
    protected float attackCounter;

    public GameObject blood;
    [SerializeField] GameObject _mesh;
    [SerializeField] private AudioClip _takeDamageSFX;

    public GameObject key;


    private void Awake()
    {
        _myAnim = GetComponentInChildren<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _myAnim.SetBool("moving", false);
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        switch (type)
        {
            case TypeOfEnemy.Melee:
                {
                    SetCommonZombie();
                    break;
                }
            case TypeOfEnemy.Ranged:
                {
                    SetRangedZombie();
                    break;
                }
            case TypeOfEnemy.Boss:
                {
                    SetBossZombie();
                    break;
                }
        }
    }

    private void Start()
    {
        _myAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_level4) _player = GameObject.FindGameObjectWithTag("Lolo").transform;
    }


    protected void ChasePlayer(float chaseRadius, float attackRadius)
    {
        float distance = Vector3.Distance(_player.position, transform.position);
        FollowPlayer();
        if (distance <= chaseRadius && distance > attackRadius)
        {
            _myAnim.SetBool("moving", true);
            _navMeshAgent.SetDestination(_player.position);
            transform.LookAt(_player);
            _isAttacking = false;
        }
        else if (distance <= attackRadius)
        {
            _isAttacking = true;
            _myAnim.SetBool("moving", false);
            //_navMeshAgent.isStopped = true;
            transform.LookAt(_player);
            Attack();
        }
        else
            _myAnim.SetBool("moving", false);
    }

    private void FollowPlayer()
    {
        if (_isAttacking) _navMeshAgent.isStopped = true;
        else _navMeshAgent.isStopped = false;
    }
    
    public abstract void Attack();

    public void TakeDamage(float val)
    {
        _myAudioSource.clip = _takeDamageSFX;
        if (!_myAudioSource.isPlaying)
        {
            _myAudioSource.Play();
        }
        _life -= val;
        
        Instantiate(blood, transform.position, transform.rotation, this.transform);
        if (_life <= 0) DestroyObject(); Debug.LogError("F");

    }


    private void DestroyObject()
    {
        if (type == TypeOfEnemy.Boss)
        {
            key.gameObject.SetActive(true);
        }
        Destroy(this.gameObject);
    }


    //Setear valores intrinsicos
    private void SetCommonZombie()
    {
        _life = FlyweightPointer.CommonZombie.maxLife;
    }
    private void SetRangedZombie()
    {
        _life = FlyweightPointer.RangeZombie.maxLife;
    }
    private void SetBossZombie()
    {
        _life = FlyweightPointer.Boss.maxLife;
    }
}

public enum TypeOfEnemy{
    Melee,
    Ranged,
    Boss

}
