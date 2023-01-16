using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowRangeCombat : RangeCombat
{
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (_attackCooldown < 0)
        {
            Projectile projectile = Instantiate(_projectile, _shotPoint.position, transform.rotation);
            projectile.SetRangeCombat(this);
            projectile.AddStartImpulse(transform.forward);
            _attackCooldown = 1 / _attackPerSecond;
        }
    }
}