using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _targetMin;
    [SerializeField] private float _targetMax;
    [SerializeField] private float _maxDelta;
    [SerializeField] private AudioSource _alarm;

    private Coroutine _coroutine;

    public void StartAlarm(bool isIncrease)
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        if (isIncrease == true)
        {
            _coroutine = StartCoroutine(PlayOn(_targetMax));
        }
        else
        {
            _coroutine = StartCoroutine(PlayOn(_targetMin));
        }
    }

    public IEnumerator PlayOn(float target)
    {
        while (_alarm.volume != target)
        {
            PlayAlarm(target);
            yield return null;
        }
    }

    public void PlayAlarm(float target)
    {
        _alarm.volume = Mathf.MoveTowards(_alarm.volume, target, _maxDelta * Time.deltaTime);
    }
}
