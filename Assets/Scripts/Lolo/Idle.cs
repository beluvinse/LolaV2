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
        _lolo.myAnim.SetBool("followLola", false); //esto creo q deberia estar en los onexit d los otros estados
    }

    public override void OnExit()
    {
    }

    public override void Update()
    {
        
            if (_lolo.CheckDistance())
            {
                fsm.ChangeState(LoloStates.FollowLola);
            }
            
    }

}
