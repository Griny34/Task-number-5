using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.TryGetComponent<MovementCrook> (out var Crook))
        {
            _alarm.StartAlarm(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.TryGetComponent<MovementCrook> (out var Crook))
        {
            _alarm.StartAlarm(false);
        }
    }
}
