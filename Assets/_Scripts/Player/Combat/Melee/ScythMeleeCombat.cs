using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScythMeleeCombat : Combat
{
    [SerializeField] private Transform _attackCenter;
    [SerializeField] public float _attackRadius;

    [SerializeField] private Transform _player;
    [SerializeField] private float _nonAttackRadius;

    protected override void Update()
    {
        base.Update();
        if (_attackCooldown < 0)
        {
            foreach (Collider collider in Physics.OverlapSphere(_attackCenter.position, _attackRadius))
            {
                if (collider.TryGetComponent<EnemyStats>(out EnemyStats enemyStats)
                    && Vector3.Distance(_player.position, collider.transform.position) > _nonAttackRadius)
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
        Gizmos.color = Color.blue;
        Vector3 circlePosition = _attackCenter == null ? Vector3.zero : _attackCenter.position;
        Gizmos.DrawWireSphere(circlePosition, _attackRadius);

        Gizmos.color = Color.white;
        circlePosition = _player == null ? Vector3.zero : _player.position;
        Gizmos.DrawWireSphere(circlePosition, _nonAttackRadius);
    }
}