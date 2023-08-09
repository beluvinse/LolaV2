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
    [SerializeField] private Material _Lolo1;
    [SerializeField] private Material _Lolo2;
    [SerializeField] private Material _Lolo3;
    [SerializeField] private Material _Lolo4;
    [SerializeField] private Material _Lolo5;

    private void Start()
    {
        SetShaderRange(8f);
    }

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
        _Lolo1.SetVector("_PlayerPosition", transform.position);
        _Lolo2.SetVector("_PlayerPosition", transform.position);
        _Lolo3.SetVector("_PlayerPosition", transform.position);
        _Lolo4.SetVector("_PlayerPosition", transform.position);
        _Lolo5.SetVector("_PlayerPosition", transform.position);
    }


    public void SetShaderRange(float range)
    {
        Debug.Log("hallo");
        _zombie1Mat.SetFloat("_Range", range);
        _zombie2Mat.SetFloat("_Range", range);
        _zombie3Mat.SetFloat("_Range", range);
        _floorMat.SetFloat("_Range", range);
        _zombieBulletMat.SetFloat("_Range", range);
        _keyMat.SetFloat("_Range", range);
        _ammoMat.SetFloat("_Range", range);
        _medKitMat.SetFloat("_Range", range);
        _Lolo1.SetFloat("_Range", range);
        _Lolo2.SetFloat("_Range", range);
        _Lolo3.SetFloat("_Range", range);
        _Lolo4.SetFloat("_Range", range);
        _Lolo5.SetFloat("_Range", range);
    }
}
