using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderZombies : MonoBehaviour
{
    [SerializeField] private Material _zombie1Mat;
    [SerializeField] private Material _zombie2Mat;
    [SerializeField] private Material _zombie3Mat;
    [SerializeField] private Material _floorMat;

    void Update()
    {
        _zombie1Mat.SetVector("_PlayerPosition", transform.position);
        _zombie2Mat.SetVector("_PlayerPosition", transform.position);
        _zombie3Mat.SetVector("_PlayerPosition", transform.position);
        _floorMat.SetVector("_PlayerPosition", transform.position);
    }
}
