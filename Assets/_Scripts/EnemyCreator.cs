using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private float spawnPerSecond;
    private float spawnCoolDown;

    private void Update()
    {
        if (spawnCoolDown <= 0)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-45, 45), 1.4f, Random.Range(-45, 45));
            Instantiate(Enemy, randomPosition, Quaternion.identity);
            spawnCoolDown = 1 / spawnPerSecond;
        }
        else
        {
            spawnCoolDown -= Time.deltaTime;
        }
    }
}