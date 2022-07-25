using System.Collections;
using UnityEngine;

public class TimeDelayTransition : Transition
{
    [SerializeField] private float _timeToWaitUntilNextState;
    [SerializeField] private float _timeOffsetSpread;

    private void Start()
    {
        _timeToWaitUntilNextState += Random.Range(-_timeOffsetSpread, _timeOffsetSpread);
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(_timeToWaitUntilNextState);

        NeedTransit = true;
    }
}