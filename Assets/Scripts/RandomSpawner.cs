using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float spawnRate = 2.0f; 
    public float spawnRangeX = 10.0f; 
    public float spawnHeight = 5.0f; 

    private float nextSpawnTime = 0.0f;

    void Update()
    {
        // Check if it's time to spawn a new asteroid
        if (Time.time >= nextSpawnTime)
        {
            SpawnAsteroid();
            nextSpawnTime = Time.time + 1 / spawnRate;
        }
    }

    void SpawnAsteroid()
    {
        float spawnX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(spawnX, spawnHeight, transform.position.z);

        GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        EnemyMover mover = asteroid.AddComponent<EnemyMover>();
        mover.speed = 3.0f;
    }
}
