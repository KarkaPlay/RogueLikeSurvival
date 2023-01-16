using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrower : RangeCombat
{
    protected override void Update()
    {
        base.Update();
        if (_attackCooldown < 0)
        {
            Projectile projectile = Instantiate(_projectile, _shotPoint.position, transform.rotation);

            projectile.SetRangeCombat(this);

            projectile.SetTarget(_targetPoint);

            _attackCooldown = 1 / _attackPerSecond;
        }
    }
}