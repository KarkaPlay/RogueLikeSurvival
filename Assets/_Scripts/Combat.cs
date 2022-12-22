using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] private float _attackPerSecond;
    protected float _attackCooldown;

    protected virtual void Update()
    {
        _attackCooldown -= Time.deltaTime;
        if (_attackCooldown < -1)
        {
            _attackCooldown = -1;
        }
    }

    protected virtual void DealDamage(CharacterStats characterStats)
    {
        if (_attackCooldown < 0)
        {
            characterStats.TakeDamage(_damage);
            _attackCooldown = 1 / _attackPerSecond;
        }
    }
}