using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterection : MonoBehaviour
{
    public Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Superman"))
        {
            _animator.SetTrigger("Trigger");
        }
    }
}
