using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upBound;
    [SerializeField] private float _maxDelta;
    [SerializeField] private AudioSource _alarm;

    private bool _isInside = false;
    private bool _outSide = false;
    private int _maxVolume = 1;

    private void Update()
    {
        if(_isInside == true)
        {
            if(_alarm.volume == _maxVolume)
            {
                _isInside = false;
            }

            PlayAlarm();
        }

        if(_outSide == true)
        {
            StopAlarm();
        }
    }

    private void PlayAlarm()
    {
        _alarm.volume = Mathf.MoveTowards(_alarm.volume, _upBound, _maxDelta * Time.deltaTime);
    }

    private void StopAlarm()
    {
        _alarm.volume = Mathf.MoveTowards(_alarm.volume, _lowerBound, _maxDelta * Time.deltaTime);
    }


    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.transform.TryGetComponent<MovementCrook>(out var crook))
        {
            _isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<MovementCrook>(out var crook))
        {
            _outSide = true;
        }
    }
}
