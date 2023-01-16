using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeCombat : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackPerSecond;
    private float _attackCooldown;

    private void Update()
    {
        _attackCooldown -= Time.deltaTime;
        if (_attackCooldown < -1)
        {
            _attackCooldown = -1;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            if (_attackCooldown < 0)
            {
                playerStats.TakeDamage(_damage);
                _attackCooldown = 1 / _attackPerSecond;
            }
        }
    }
}