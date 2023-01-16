using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [SerializeField] private ExpSphere expSphere;

    protected override void Die()
    {
        base.Die();
        Instantiate(expSphere, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}