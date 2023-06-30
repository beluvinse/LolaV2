using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    [SerializeField] private AudioSource _myAudioSource;
    [SerializeField] private AudioMixer _audioControl;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMusicVolume(float sliderValue)
    {
        _audioControl.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
    }
    
    public void SetSFXVolume(float sliderValue)
    {
        _audioControl.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
    }

    public void PlayAudio(AudioClip clip)
    {
        if (_myAudioSource.clip == clip) return;
        _myAudioSource.Stop();
        _myAudioSource.clip = clip;
        _myAudioSource.Play();
    }
}
