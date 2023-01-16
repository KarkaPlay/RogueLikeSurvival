using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMeleeCombat : Combat
{
    [SerializeField] private Transform _attackCenter;
    [SerializeField] private float _attackRadius;

    protected override void Update()
    {
        base.Update();
        if (_attackCooldown < 0)
        {
            foreach (Collider collider in Physics.OverlapSphere(_attackCenter.position, _attackRadius))
            {
                if (collider.TryGetComponent<EnemyStats>(out EnemyStats enemyStats))
                {
                    DealDamage(enemyStats);
                }
            }
            _attackCooldown = 1 / _attackPerSecond;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 circlePosition = _attackCenter == null ? Vector3.zero : _attackCenter.position;
        Gizmos.DrawWireSphere(circlePosition, _attackRadius);
    }
}