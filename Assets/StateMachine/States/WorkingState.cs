using UnityEngine;

public class WorkingState : IState
{
    private float _timeToWork = 3f;
    private float _timer;
    private IStateSwitcher _stateSwitcher;
    public WorkingState(IStateSwitcher stateSwitcher)
    {
        _stateSwitcher = stateSwitcher;
    }
    public void Enter()
    {
        Debug.Log("Начинаю работу");
    }

    public void Exit()
    {
        Debug.Log("Я закончил работу");
    }

    public void Update()
    {
        Debug.Log("Я работаю");
        _timer += Time.deltaTime;
        if (_timer >= _timeToWork)
        {
            _stateSwitcher.SwitchState<MoveToHomeState>();
            _timer = 0f;
        }
    }
}
