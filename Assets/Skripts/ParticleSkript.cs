using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSkript : MonoBehaviour
{
    [Header("Игрок")]
    [SerializeField] private Transform Player;
    void Update()
    {
        transform.position = Player.position;
    }
}
