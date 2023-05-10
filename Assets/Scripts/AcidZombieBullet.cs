using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidZombieBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private GameObject _acidPuddle;
    [SerializeField] private LayerMask layer;

    void Update()
    {


        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, Vector3.down, out hit, 0.5f, layer))
        {
            Debug.Log("aaa");
            //var puddle = Instantiate(_acidPuddle, hit.point, Quaternion.identity);
            var puddle = AcidPuddleFactory.Instance.GetObject();
            puddle.transform.position = hit.point;
            puddle.transform.position.WithAxis(Axis.Y, -0.25f);
            AcidBulletFactory.Instance.ReturnBullet(this);
        }

    }

   public static void TurnOn(AcidZombieBullet b)
    {
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(AcidZombieBullet b)
    {
        b.gameObject.SetActive(false);
    }



    public float GetSpeed()
    {
        return _speed;
    }

}
