using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyMagic : Combat
{
    [SerializeField] private float _attackRadius;

    protected override void Update()
    {
        base.Update();
        if (_attackCooldown < 0)
        {
            foreach (Collider collider in Physics.OverlapSphere(transform.position, _attackRadius))
            {
                if (collider.TryGetComponent<EnemyStats>(out EnemyStats enemyStats))
                {
                    DealDamage(enemyStats);
                }
            }
            _attackCooldown = 1 / _attackPerSecond;
        }
    }

    public override void Improve()
    {
        base.Improve();
        _attackRadius *= 1.2f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        Gizmos.DrawWireSphere(transform.position, _attackRadius);
    }
}