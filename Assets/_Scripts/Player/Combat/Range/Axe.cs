using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Projectile
{
    [SerializeField] private Transform _boxCenter;
    [SerializeField] private Vector3 _boxHalfExtents;

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
                foreach (Collider collider in Physics.OverlapBox(_boxCenter.position, _boxHalfExtents, transform.rotation))
                {
                    if (collider.TryGetComponent<EnemyStats>(out EnemyStats enemyStatsInWave))
                    {
                        enemyStatsInWave.TakeDamage(_rangeCombat.GetDamageValue());
                    }
                }
            }
            Destroy(gameObject);
        }
        //
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Vector3 boxPosition = _boxCenter == null ? Vector3.zero : _boxCenter.position;
        Gizmos.DrawWireCube(boxPosition, _boxHalfExtents);
    }
}