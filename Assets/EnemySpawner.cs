using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    
    public float spawnRadius = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position + new Vector3(Random.onUnitSphere.x * spawnRadius, 0, Random.onUnitSphere.z * spawnRadius);
        
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
