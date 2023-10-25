using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NpcStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public NpcStateMachine(NpcController npcController,Transform home,Transform work)
    {
        _states = new List<IState>();
        _states.Add(new MoveToWorkState(this, npcController, work,npcController.Speed));
        _states.Add(new MoveToHomeState(this, npcController, home,npcController.Speed));
        _states.Add(new WorkingState(this));
        _states.Add(new RestingState(this,npcController.RestMusic));
        _currentState = _states[1];
        _currentState.Enter();
    }

    public void SwitchState<T>() where T : IState
    {
        IState state = _states.FirstOrDefault(state => state is T);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }
    public void Update() =>_currentState.Update();
}
