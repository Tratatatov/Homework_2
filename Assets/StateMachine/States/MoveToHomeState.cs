using Unity.VisualScripting;
using UnityEngine;

public class MoveToHomeState : IState
{

    private float _stopDistance = 0.5f;

    private readonly IStateSwitcher _stateSwitcher;

    private readonly NpcController _npcController;

    private Transform _target;

    private float _speed;

    public MoveToHomeState(IStateSwitcher stateSwitcher, NpcController npcController, Transform target,float speed)
    {
        _stateSwitcher = stateSwitcher;
        _npcController = npcController;
        _target = target;
        _speed = speed;
    }

    protected CharacterController CharacterController => _npcController.CharacterController;
    public void Enter()
    {
        Debug.Log("Я пошел на домой");
    }

    public void Exit()
    {
        Debug.Log("Вот я и дома");
    }

    public void Update()
    {
        Vector3 direction = _target.position - _npcController.transform.position;
        _npcController.CharacterController.Move(direction.normalized * _speed*Time.deltaTime);
        if (Vector3.Distance(_npcController.transform.position, _target.position) <= _stopDistance)
        {
            _stateSwitcher.SwitchState<RestingState>();
        }
    }
}
