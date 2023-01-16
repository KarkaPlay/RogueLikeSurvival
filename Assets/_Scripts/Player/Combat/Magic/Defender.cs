using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [HideInInspector]
    public float Damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyStats>(out EnemyStats enemyStats))
        {
            enemyStats.TakeDamage(Damage);
        }
    }
}