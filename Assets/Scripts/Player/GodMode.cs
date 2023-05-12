using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{
    CapsuleCollider _cc;
    Rigidbody _rb;

    void Start()
    {
        _cc = GetComponent<CapsuleCollider>();
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.G))
        {
            Debug.Log("god");
            EnableGodMode();
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.H))
        {
            Debug.Log("godn't");
            DisableGodMode();
        }
    }

    void EnableGodMode()
    {
        _cc.enabled = false;
        _rb.useGravity = false;
    }

    void DisableGodMode()
    {
        _cc.enabled = true;
        _rb.useGravity = true;
    }
}
