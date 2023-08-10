using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : CurrentState
{
    Lolo _lolo;

    public Idle(Lolo lolo)
    {
        _lolo = lolo;
    }

    public override void OnEnter()
    {
    }

    public override void OnExit()
    {
    }

    public override void Update()
    {
        if (!_lolo.CheckHP())
        {
            if (_lolo.CheckDistance())
            {
                fsm.ChangeState(LoloStates.FollowLola);
            }
        }
        else
        {
            fsm.ChangeState(LoloStates.Runaway);
        }
            
    }

}
