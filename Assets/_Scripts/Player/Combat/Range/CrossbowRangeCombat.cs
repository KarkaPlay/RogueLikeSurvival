using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowRangeCombat : RangeCombat
{
    protected override void Update()
    {
        base.Update();
        if (_attackCooldown < 0)
        {
            Projectile projectile = Instantiate(_projectile, _shotPoint.position, transform.rotation);
            projectile.AddStartImpulse(transform.forward);
            projectile.SetRangeCombat(this);
            _attackCooldown = 1 / _attackPerSecond;
        }
    }
}