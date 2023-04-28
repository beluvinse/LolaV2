using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRequester : MonoBehaviour
{
    [Header("Audio Clip")]
    [SerializeField] private AudioClip _audioToRequest;

    private void Start()
    {
        AudioManager.Instance.PlayAudio(_audioToRequest);
    }
}
