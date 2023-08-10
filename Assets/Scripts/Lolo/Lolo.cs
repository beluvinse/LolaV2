using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(HealthManager))]
public class Lolo : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] protected float _HPthreshold;
    [SerializeField] float _separationRadius;


    [SerializeField] protected Transform _player;

    [Header("Follow")]
    [SerializeField] protected float _followRadius;

    public Animator myAnim;



    private NavMeshAgent _navMeshAgent;
    private HealthManager _healthManager;
    LoloFSM _fsm;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _healthManager = GetComponent<HealthManager>();
    }

    private void Start()
    {
        _fsm = new LoloFSM();
        _fsm.AddState(LoloStates.Idle, new Idle(this));
        _fsm.AddState(LoloStates.Runaway, new Runaway(this));
        _fsm.AddState(LoloStates.FollowLola, new FollowLola(this));

        _fsm.ChangeState(LoloStates.Idle);
    }

    private void Update()
    {
        _fsm.Update();
    }


    public void FollowLola()
    {
        _navMeshAgent.SetDestination(_player.position);
        transform.LookAt(_player);

        if (Vector3.Distance(transform.position, _player.position) <= _separationRadius)
            myAnim.SetBool("followLola", false);
        else
            myAnim.SetBool("followLola", true);

    }

    public void RunAway()
    {

    }

    public bool CheckHP()
    {
        //si su vida esta pordebajo del threshold, huye
        if (_healthManager.getHealth() <= _HPthreshold)
            return true;
        return false;
    }

    public bool CheckDistance()
    {
        //si esta a distancia de lola, la sigue
        if (Vector3.Distance(transform.position, _player.position) <= _followRadius) return true;
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _followRadius);
    }
}
