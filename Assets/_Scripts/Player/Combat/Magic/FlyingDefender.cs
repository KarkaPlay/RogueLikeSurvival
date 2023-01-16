using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDefender : Combat
{
    [SerializeField] private float _attackRadiusZone;
    [SerializeField] private float _speedFlying;
    [SerializeField] private Defender _defenderPrefab;
    [SerializeField] private Vector3 targetPosition;

    // Start is called before the first frame update
    private void Start()
    {
        targetPosition = GetRandomPointInAttackZoneNorth();
        _defenderPrefab.Damage = _damage;
    }

    // Update is called once per frame
    private new void Update()
    {
        _defenderPrefab.transform.position = Vector3.MoveTowards(_defenderPrefab.transform.position, targetPosition, _speedFlying * Time.deltaTime);
        if (targetPosition == _defenderPrefab.transform.position)
        {
            targetPosition = (Random.Range(0, 100) % 2 == 0) ?
            GetRandomPointInAttackZoneNorth() : GetRandomPointInAttackZoneSouth();
        }
    }

    private Vector3 GetRandomPointInAttackZoneNorth()
    {
        float x = Random.Range(transform.position.x - _attackRadiusZone, transform.position.x + _attackRadiusZone);
        float y = 1;
        float z = Mathf.Sqrt(Mathf.Abs(_attackRadiusZone * _attackRadiusZone -
                    (x - transform.position.x) * (x - transform.position.x)))
                    + transform.position.z;
        return new Vector3(x, y, z);
    }

    private Vector3 GetRandomPointInAttackZoneSouth()
    {
        float x = Random.Range(transform.position.x - _attackRadiusZone, transform.position.x + _attackRadiusZone);
        float y = 1;
        float z = -Mathf.Sqrt(Mathf.Abs(_attackRadiusZone * _attackRadiusZone -
                    (x - transform.position.x) * (x - transform.position.x)))
                    + transform.position.z;

        return new Vector3(x, y, z);
    }

    public override void Improve()
    {
        base.Improve();
        _speedFlying *= 1.2f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, _attackRadiusZone);
    }
}