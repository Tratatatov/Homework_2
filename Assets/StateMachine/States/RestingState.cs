using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestingState : IState
{
    private float _timeToRest=3f;
    private float _timer;
    [SerializeField] private Transform _target;

    private readonly IStateSwitcher _stateSwitcher;

    private AudioSource _audioSource;
    public RestingState(IStateSwitcher stateSwitcher,AudioSource audioSource)
    {
        _stateSwitcher = stateSwitcher;
        _audioSource = audioSource;
    }
    public void Enter()
    {
        Debug.Log("Пора бы отдохнуть");
        _audioSource.Play();
    }

    public void Exit()
    {
        Debug.Log("Отдых закончился");
        _audioSource.Pause();
    }

    public void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _timeToRest)
        {
            _stateSwitcher.SwitchState<MoveToWorkState>();
            _timer = 0f;
        }
    }
}
