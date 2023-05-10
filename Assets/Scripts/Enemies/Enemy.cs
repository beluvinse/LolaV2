using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public abstract class Enemy : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] protected float _life;
    [SerializeField] protected float _maxLife;
    [SerializeField] protected float _damage;
    [SerializeField] protected TypeOfEnemy type;
    [SerializeField] private AudioClip _takeDamageSFX;
    private AudioSource _myAudioSource;
    protected NavMeshAgent _navMeshAgent;
    public GameObject blood;

    private Manager _manager;

    private void Start()
    {
        _manager = GetComponentInParent<Manager>();
        _myAudioSource = GetComponent<AudioSource>();
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
        if (_life <= 0) DestroyObject();

    }


    private void DestroyObject()
    { 
        Destroy(this.gameObject);
    }


}

public enum TypeOfEnemy{
    Melee,
    Ranged,
    RangedAcid

}
