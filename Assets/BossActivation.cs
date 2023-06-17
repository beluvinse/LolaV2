using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("xxx");

        var x = other.GetComponent<ShaderZombies>();
        if (x)
        {
            Debug.Log("omaiga");
            x.SetShaderRange(15f);
        }
    }
}
