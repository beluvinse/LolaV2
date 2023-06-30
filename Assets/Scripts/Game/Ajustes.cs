using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ajustes : MonoBehaviour
{
    public Slider volume;
    public AudioListener listener;


    public float volumeValue;

    public void Start()
    {
        volume.value = PlayerPrefs.GetFloat("volumeAudio", 1f);
        AudioListener.volume = volume.value;
    }


    public void VolumeSlider(float valor)
    {
        volumeValue = valor;
        PlayerPrefs.SetFloat("volumeAudio", volumeValue);
        AudioListener.volume = volume.value;
    }

}
