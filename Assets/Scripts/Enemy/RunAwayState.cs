using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class RunAwayState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private float _xRunAwayCoordinate;

    private const string Run = "Run";
    private const string Idle = "Idle";

    private Animator _animator;
    private Vector3 _runTarget;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _runTarget = new Vector3(_xRunAwayCoordinate, transform.position.y, transform.position.z);
        StartCoroutine(RunAway());
    }

    private IEnumerator RunAway()
    {
        _animator.Play(Run);

        while (transform.position != _runTarget)
        {
            yield return new WaitForEndOfFrame();
            transform.position = Vector2.MoveTowards(transform.position, _runTarget, _speed * Time.deltaTime);
        }

        _animator.Play(Idle);
    }
}