using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMeleeCombat : Combat
{
    [SerializeField] private Transform _attackCenter;

    [SerializeField] private Vector3 _halfBoxExtens;

    private void Start()
    {
    }

    protected override void Update()
    {
        base.Update();
        if (_attackCooldown < 0)
        {
            foreach (Collider collider in Physics.OverlapBox(_attackCenter.position, _halfBoxExtens, _attackCenter.transform.rotation))
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
        Vector3 boxPosition = _attackCenter == null ? Vector3.zero : _attackCenter.position;
        Gizmos.DrawWireCube(boxPosition, _halfBoxExtens);
    }
}