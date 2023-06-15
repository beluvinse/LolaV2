using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderZombies : MonoBehaviour
{
    [SerializeField] private Material _effectMat;

    void Update()
    {
        _effectMat.SetVector("_PlayerPosition", transform.position);
    }
}
