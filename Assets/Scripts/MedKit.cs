using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    private float _health;
    public float healing;
    public GameObject player;
    public GameObject healParticle;
    [SerializeField] private AudioClip _healSFX;
    private AudioSource _myAudioSource;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _myAudioSource = player.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && player.GetComponent<HealthManager>().getHealth() < 100)
        {
            Heal();
            Destroy(this.gameObject);
        }
    }
    
    void Heal()
    {
        _health = player.GetComponent<HealthManager>().getHealth();

        float health = _health + healing;
        if (health > 100)
            health = 100;
        player.GetComponent<HealthManager>().setHealth(health);
        _myAudioSource.clip = _healSFX;
        if (!_myAudioSource.isPlaying)
        {
            _myAudioSource.Play();
        }
        Instantiate(healParticle, this.gameObject.transform.position, this.gameObject.transform.rotation, player.transform);
    }

}
