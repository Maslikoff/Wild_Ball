using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBall : MonoBehaviour
{
    [Header("Анимация")]
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Касание игрока с мячом
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Superman"))
        {
            _animator.SetTrigger("Trigger");
        }
    }
}
