using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderZombies : MonoBehaviour
{
    [SerializeField] private Material _zombie1Mat;
    [SerializeField] private Material _zombie2Mat;
    [SerializeField] private Material _zombie3Mat;
    [SerializeField] private Material _floorMat;
    [SerializeField] private Material _zombieBulletMat;
    [SerializeField] private Material _keyMat;
    [SerializeField] private Material _ammoMat;
    [SerializeField] private Material _medKitMat;

    void Update()
    {
        _zombie1Mat.SetVector("_PlayerPosition", transform.position);
        _zombie2Mat.SetVector("_PlayerPosition", transform.position);
        _zombie3Mat.SetVector("_PlayerPosition", transform.position);
        _floorMat.SetVector("_PlayerPosition", transform.position);
        _zombieBulletMat.SetVector("_PlayerPosition", transform.position);
        _keyMat.SetVector("_PlayerPosition", transform.position);
        _ammoMat.SetVector("_PlayerPosition", transform.position);
        _medKitMat.SetVector("_PlayerPosition", transform.position);
    }
}
