using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Игрок")]
    [SerializeField] private Transform SuperMan;

    [Header("Расстояние от камеры до игрока")] 
    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - SuperMan.position;
    }

    private void FixedUpdate()
    {
        transform.position = SuperMan.position + _offset;
    }
}
