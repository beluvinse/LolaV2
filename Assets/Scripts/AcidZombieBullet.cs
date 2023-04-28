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
        Debug.Log("a");
        if (Physics.Raycast(this.transform.position, Vector3.down, out hit, 0.5f, layer))
        {
            Debug.Log("aaa");
            var puddle = Instantiate(_acidPuddle, hit.point, Quaternion.identity);
            puddle.transform.position.WithAxis(Axis.Y, -0.25f);
            Destroy(this.gameObject);
        }
    }

    public float GetSpeed()
    {
        return _speed;
    }

}
