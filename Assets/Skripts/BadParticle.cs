using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadParticle : MonoBehaviour
{
    [SerializeField] private Transform BadGuy;
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Superman"))
        {
            transform.position = BadGuy.position;
        }
    }
}
