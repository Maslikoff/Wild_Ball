using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [Header("Дверь")]
    [SerializeField] private GameObject Door;

    /// <summary>
    /// Касание двери
    /// </summary>
    /// <param name="ball">игрок</param>
    private void OnTriggerStay(Collider ball)
    {
        if (ball.CompareTag("Box"))
        {
            Door.SetActive(false);
        }
    }
}
