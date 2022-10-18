using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMCamera : MonoBehaviour
{
    public float Forse;
    public CharacterController Controller;

    private void Update()
    {
        float horizotal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizotal, 0f,vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Controller.Move(direction * Forse * Time.deltaTime);
        }
    }
}
