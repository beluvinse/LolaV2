using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesTrigger : MonoBehaviour
{

    [SerializeField] AudioClip _spikesSFX;

    AudioSource _myAudioSource;

    private void Start()
    {
        _myAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        GetComponentInChildren<Animation>().Play();
        _myAudioSource.clip = _spikesSFX;
        if (!_myAudioSource.isPlaying)
        {
            _myAudioSource.Play();
        }
        yield return new WaitForSeconds(1);
    }
}
