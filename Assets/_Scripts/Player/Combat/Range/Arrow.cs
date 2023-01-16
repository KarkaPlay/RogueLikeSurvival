using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Projectile
{
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != gameObject.layer)
        {
            if (other.TryGetComponent<EnemyStats>(out EnemyStats enemyStats))
            {
                enemyStats.TakeDamage(_rangeCombat.GetDamageValue());
                Destroy(gameObject);
            }
        }
    }
}