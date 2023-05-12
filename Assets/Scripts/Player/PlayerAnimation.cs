using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _myAnim;
    [SerializeField] private string _xAxisName;
    [SerializeField] private string _zAxisName;
    [SerializeField] private AnimationClip _shootAnimation;

    private void Start()
    {
        _myAnim = GetComponentInChildren<Animator>();

    }

    public void MoveAnimation(float hInput, float vInput)
    {
        _myAnim.SetFloat(_xAxisName, hInput);
        _myAnim.SetFloat(_zAxisName, vInput);
    }

    public void Trigger(string val)
    {
        _myAnim.SetTrigger(val);
    }


}
