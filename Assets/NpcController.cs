using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class NpcController : MonoBehaviour
{

    [SerializeField] private Transform _home;
    [SerializeField] private Transform _work;
    [SerializeField] private float _speed;

    private CharacterController _characterController;
    private NpcStateMachine _stateMachine;
    private AudioSource _restMusic;

    public CharacterController CharacterController => _characterController;
    public float Speed => _speed;
    public Transform Home => _home;
    public Transform Work => _work;
    public AudioSource RestMusic=>_restMusic;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _restMusic = GetComponent<AudioSource>();
        _stateMachine = new NpcStateMachine(this,_home,_work);
    }
    private void Update()
    {
        _stateMachine.Update();
    }
}
