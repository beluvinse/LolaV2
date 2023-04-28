using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private string hitTag;


    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == hitTag)
        {
            if (hitTag == "Player")
            {
                other.GetComponent<HealthManager>().TakeDamage(_damage);
                Debug.Log("mepegaste jugador ");
            }

            if (other.GetComponent<HealthManager>().getDmg())
                Destroy(this.gameObject);

        }
        if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);

        }
    }
}
