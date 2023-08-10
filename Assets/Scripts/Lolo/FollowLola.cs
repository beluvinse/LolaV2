using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLola : CurrentState
{
    Lolo _lolo;

    public FollowLola(Lolo lolo)
    {
        _lolo = lolo;
    }

    public override void OnEnter()
    {
        _lolo.myAnim.SetBool("followLola", true);
    }

    public override void OnExit()
    {

    }

    public override void Update()
    {
         _lolo.FollowLola();

       
    }


}
