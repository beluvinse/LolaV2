using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Lolo : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] protected float _life;

    [SerializeField] protected Transform _player;

    [Header("Follow")]
    [SerializeField] protected float _followRadius;

    private Animator _myAnim;
    private AudioSource _myAudioSource;


    [SerializeField] GameObject blood;
    [SerializeField] private AudioClip _takeDamageSFX;

    private NavMeshAgent _navMeshAgent;
    LoloFSM _fsm;

    private void Awake()
    {
        _myAnim = GetComponentInChildren<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _myAudioSource = GetComponent<AudioSource>();
    }
}
