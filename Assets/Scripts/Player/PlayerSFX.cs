using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSFX : MonoBehaviour
{

    [Header("Audio")]
    [SerializeField] private AudioClip _gunSFX;
    [SerializeField] private AudioClip _reloadSFX;
    [SerializeField] private AudioClip _noAmmoSFX;
    private AudioSource _myAudioSource;

    private void Start()
    {
        _myAudioSource = GetComponent<AudioSource>();

    }



    public void OnShoot(bool paused)
    {
        _myAudioSource.clip = _gunSFX;
        if (!_myAudioSource.isPlaying && paused == false) //y si el juego no esta en pausa
        {
            _myAudioSource.Play();
        }

    }

    public void OnNoAmmo()
    {
        _myAudioSource.clip = _noAmmoSFX;
        if (!_myAudioSource.isPlaying)
        {
            _myAudioSource.Play();
        }

    }
    public void OnReload()
    {
        _myAudioSource.clip = _reloadSFX;
        if (!_myAudioSource.isPlaying)
        {
            _myAudioSource.Play();
        }

    }
}
