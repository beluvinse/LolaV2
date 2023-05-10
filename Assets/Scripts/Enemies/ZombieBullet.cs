using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBullet : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float _damage;

    private void Update()
    {
        BulletBehaviour();
    }


    protected void BulletBehaviour()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        var entity = other.GetComponent<HealthManager>();
        if (entity)
        {
            entity.GetComponent<HealthManager>().TakeDamage(_damage);
            Debug.Log("mepegaste jugador ");
            ZombieBulletFactory.Instance.ReturnBullet(this);
        }
        else if (other.gameObject.tag == "Wall")
        {
            ZombieBulletFactory.Instance.ReturnBullet(this);
        }
    }

    public static void TurnOn(ZombieBullet b)
    {
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(ZombieBullet b)
    {
        b.gameObject.SetActive(false);
    }

    public float GetSpeed()
    {
        return _speed;
    }


}
