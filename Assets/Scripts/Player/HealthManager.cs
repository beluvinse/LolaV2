using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealthManager : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;

    [Header("Audio")]
    [SerializeField] private AudioClip _takeDamageSFX;
    private AudioSource _myAudioSource;

    public GameObject hurtParticle;
    [SerializeField] private bool _canTakeDamage;

    private void Start()
    {
        _health = _maxHealth;
        _myAudioSource = GetComponent<AudioSource>();
        _canTakeDamage = true;
    }

    public float getHealth()
    {
        return _health;
    }

    public void setHealth(float health)
    {
        _health = health;
    }
    
    public bool getDmg()
    {
        return _canTakeDamage;
    }

    public void setDmg(bool val)
    {
        if (val == true)
            _canTakeDamage = false;
        
        if (val == false)
            _canTakeDamage = true;
    }

    public float getMaxHealth()
    {
        return _maxHealth;
    }

    internal void Initalize()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float val)
    {
        if (_canTakeDamage)
        {
            _health -= val;
            _myAudioSource.clip = _takeDamageSFX;
            if (!_myAudioSource.isPlaying)
            {
                _myAudioSource.Play();
            }
            //Instantiate(hurtParticle, this.gameObject.transform.position, this.gameObject.transform.rotation, this.transform);
        }
    }
}

