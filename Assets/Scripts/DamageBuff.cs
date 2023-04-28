using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBuff : MonoBehaviour
{
    [SerializeField] private float _dmgBuff = 10f;
    [SerializeField] private float _time = 5f;




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().BuffGun(_dmgBuff, _time);
            Destroy(this.gameObject);
        }
    }
}
