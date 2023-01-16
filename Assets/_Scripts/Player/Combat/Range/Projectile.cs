using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    protected RangeCombat _rangeCombat;

    private bool _isGointToTarget = true;
    private Vector3 _target;
    // Start is called before the first frame update

    // Update is called once per frame
    protected virtual void Update()
    {
        if (_isGointToTarget)
            transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        _lifeTime -= Time.deltaTime;
        if (_lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddStartImpulse(Vector3 direction)
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(direction * _speed, ForceMode.Impulse);
        _isGointToTarget = false;
        //_rigidbody.velocity = new Vector3(direction.normalized.x, _rigidbody.velocity.y, direction.normalized.z) * _speed;
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }

    public void SetRangeCombat(RangeCombat rangeCombat)
    {
        _rangeCombat = rangeCombat;
    }
}