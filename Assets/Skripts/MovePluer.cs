using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovePluer : MonoBehaviour
{
    [Header("Скорость шара")]
    [SerializeField] private float Speed = 6;
    
    [Header("Компонент")]
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Передвижение
    /// </summary>
    private void FixedUpdate()
    {
        Vector3 move = new Vector3(
            Input.GetAxis("Vertical"),
            Input.GetAxis("Jump"),
            (Input.GetAxis("Horizontal") * -1)) * Speed;

        move = Vector3.ClampMagnitude(move, Speed);

        if (move != Vector3.zero)
        {
            _rigidbody.MovePosition(transform.position + move * Time.deltaTime);
            _rigidbody.MoveRotation(Quaternion.LookRotation(move));
        }
    }
}
