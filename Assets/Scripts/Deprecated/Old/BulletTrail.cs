using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private Vector3 _startingPosition;
    private float _progress;

    [SerializeField] private float _speed = 40f;

    void Start()
    {
        //_startingPosition = transform.position.WithAxis(Axis.Z, -1);
    }

    // Update is called once per frame
    void Update()
    {
        _progress = Time.deltaTime * _speed;
        transform.position = Vector3.Lerp(_startingPosition, _targetPosition, _progress);
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
    }

    public void SetStartingPosition(Vector3 startingPosition)
    {
        _startingPosition = startingPosition.WithAxis(Axis.Y, 2.87f);
    }

    public Vector3 GetTargetPosition()
    {
        return _targetPosition;
    }
}
