using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoloFSM
{
    CurrentState _currentState;

    public CurrentState currentState { get { return _currentState; } }

    Dictionary<LoloStates, CurrentState> _allStates = new Dictionary<LoloStates, CurrentState>();

    public void AddState(LoloStates key, CurrentState state)
    {
        if (state == null) return;

        _allStates.Add(key, state);
        state.fsm = this;
    }

    public void ChangeState(LoloStates key)
    {
        if (!_allStates.ContainsKey(key)) return;

        if (_currentState != null)
            _currentState.OnExit();

        _currentState = _allStates[key];
        _currentState.OnEnter();
    }

    public void Update()
    {
        _currentState.Update();
    }

}

public enum LoloStates
{
    Idle,
    FollowLola,
    Runaway
}
