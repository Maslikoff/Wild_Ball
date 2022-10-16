using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Где наш супермен")]
    [SerializeField] private Transform superMan;
    
    [Header("Расстояние от него до камеры")]
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - superMan.position;
    }

    private void FixedUpdate()
    {
        transform.position = superMan.position + offset;
    }
}
