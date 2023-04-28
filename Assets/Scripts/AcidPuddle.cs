using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidPuddle : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _time = 10f;

    private float contador;

    private HealthManager _player;
    [SerializeField] private bool _isOnPuddle = false;

    void FixedUpdate()
    {
        contador += Time.deltaTime;
        if (contador >= _time)
        {
            _isOnPuddle = false;
            Destroy(this.gameObject);
        }

        if (_isOnPuddle)
        {
            StartCoroutine(Acid());
        }

    }

   
    

    private void OnTriggerEnter (Collider other)
    {
        if (other.GetComponent<HealthManager>())
        {
            _player = other.GetComponent<HealthManager>();
            _isOnPuddle = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<HealthManager>())
        {
            _player = null;
            _isOnPuddle = false;
        }
    }


    IEnumerator Acid()
    {
        _player.TakeDamage(_damage);
        yield return new WaitForSeconds(1);
    }

    

}
