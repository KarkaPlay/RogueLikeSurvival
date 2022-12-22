using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public GameObject expPrefab;
    
    void Start()
    {
        Invoke("Die", 10);
    }
    
    protected override void Die()
    {
        base.Die();
        SpawnExp();
        Destroy(gameObject);
    }

    private void SpawnExp()
    {
        Instantiate(expPrefab, transform.position, Quaternion.identity);
    }
}