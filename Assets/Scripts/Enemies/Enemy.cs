using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public abstract class Enemy : MonoBehaviour
{
    #region
    public float MaxLife
    {
        get
        {
            return _maxLife;
        }
        set
        {
            _maxLife = Mathf.Clamp(value, 10, 200);
        }
    }
    public float Damage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = Mathf.Clamp(value, 10, 50);
        }
    }
       #endregion  

    [Header("Values")]
    [SerializeField] protected float _life;
    [SerializeField] protected float _maxLife;
    [SerializeField] protected float _damage;
    [SerializeField] protected TypeOfEnemy type;

    [SerializeField] protected Transform _player;

    [Header("Attack")]
    [SerializeField] protected float _chaseRadius;
    [SerializeField] protected float _attackRadius;
    [SerializeField] protected float _attackDelay;
    [SerializeField] protected bool _isAttacking;



    private Animator _myAnim;

    private Manager _manager;
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
    }

    private void Start()
    {
        _manager = GetComponentInParent<Manager>();
        _myAudioSource = GetComponent<AudioSource>();
    }


    private void FixedUpdate()
    {
        float distance = Vector3.Distance(_player.position, transform.position);
        FollowPlayer();
        if (distance <= _chaseRadius && distance > _attackRadius)
        {
            _myAnim.SetBool("moving", true);
            _navMeshAgent.SetDestination(_player.position);
            transform.LookAt(_player);
            _isAttacking = false;
        }
        else if (distance <= _attackRadius)
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
        if (this.gameObject.CompareTag("Boss"))
        {
            key.gameObject.SetActive(true);
        }
        Destroy(this.gameObject);
    }

    public void Reveal()
    {
        Debug.Log("AAA");
        _mesh.SetActive(true);
    }


}

public enum TypeOfEnemy{
    Melee,
    Ranged,
    RangedAcid

}
