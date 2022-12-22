using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeCombat : Combat
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            DealDamage(playerStats);
        }
    }
}