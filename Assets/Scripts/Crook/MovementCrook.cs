using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementCrook : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _velocity;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _velocity = Vector2.right * _speed;
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _velocity;
    }
}
