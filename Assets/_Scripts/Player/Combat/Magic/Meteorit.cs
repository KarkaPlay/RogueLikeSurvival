using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorit : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    private MeteoritGenerator _meteorGenerator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != gameObject.layer)
        {
            foreach (Collider collider in Physics.OverlapSphere(transform.position, _explosionRadius))
            {
                if (collider.TryGetComponent<EnemyStats>(out EnemyStats enemyStats))
                {
                    enemyStats.TakeDamage(_meteorGenerator.GetDamageValue());
                }
            }

            Destroy(gameObject);
        }
    }

    public void SetMeteoritGenerator(MeteoritGenerator meteoritGenerator)
    {
        _meteorGenerator = meteoritGenerator;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}