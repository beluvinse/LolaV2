using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskSync : MonoBehaviour
{
    //Todo esto integrado directamente al Player

    [Header("Rays")]
    [SerializeField] private LayerMask _viewMask;
    [Header("Shader Components")]
    [SerializeField] private Material _maskMaterial;
    [SerializeField] private string _playerPosName = "_PlayerPosition";
    [SerializeField] private string _sizeName = "_MaskSize";

    private Camera _camera;
    private Vector3 _dir, _view;

    private Ray _checkRay;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        _dir = (_camera.transform.position - transform.position).normalized;
        _checkRay = new Ray(transform.position, _dir);

        if (Physics.Raycast(_checkRay, _viewMask))
        {
            _maskMaterial.SetFloat(_sizeName, 1f);
        }
        else
        {
            _maskMaterial.SetFloat(_sizeName, 0f);
        }

        _view = _camera.WorldToViewportPoint(transform.position);
        _maskMaterial.SetVector(_playerPosName, _view);
    }
}
