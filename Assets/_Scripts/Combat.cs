using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] public float _damage;
    [SerializeField] public float _attackPerSecond;
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
        }
    }

    public float GetDamageValue()
    {
        return _damage;
    }

    public virtual void Improve()
    {
        _damage *= 1.2f;
        _attackPerSecond *= 1.2f;
    }
}