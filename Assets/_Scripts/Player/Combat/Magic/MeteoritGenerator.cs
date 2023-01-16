using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritGenerator : Combat
{
    [SerializeField] private float _attackRadiusZone;

    [SerializeField]
    private Meteorit meteorit;

    [SerializeField] private float _spawnHeight;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (_attackCooldown < 0)
        {
            Vector3 spawnMeteorPosition = GetRandomPointInAttackSquare();
            Meteorit temp = Instantiate(meteorit, spawnMeteorPosition, Quaternion.identity);
            temp.SetMeteoritGenerator(this);
            _attackCooldown = 1 / _attackPerSecond;
        }
    }

    private Vector3 GetRandomPointInAttackSquare()
    {
        float x = Random.Range(transform.position.x - _attackRadiusZone, transform.position.x + _attackRadiusZone);
        float y = _spawnHeight;
        float z = Random.Range(transform.position.z - _attackRadiusZone, transform.position.z + _attackRadiusZone);
        return new Vector3(x, y, z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        //Gizmos.DrawWireSphere(transform.position, _attackRadiusZone);
        Gizmos.DrawCube(new Vector3(transform.position.x, transform.position.y + _spawnHeight, transform.position.z),
            new Vector3(_attackRadiusZone * 2, 0.1f, _attackRadiusZone * 2));
    }
}