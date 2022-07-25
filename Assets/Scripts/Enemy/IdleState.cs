using UnityEngine;

[RequireComponent(typeof(Animator))]

public class IdleState : State
{
    private const string Idle = "Idle";

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play(Idle);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}