using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float initialSpawnRate = 2.0f; // Initial spawn rate (in seconds)
    public float minSpawnRate = 0.5f; // Minimum spawn rate (in seconds)
    public float spawnRateDecrease = 0.1f; // Rate at which spawn rate decreases (in seconds)
    public float spawnRangeX = 10.0f;
    public float spawnHeight = 5.0f;
    public float moverSpeed = 3.0f;
    public bool spawnInGroup;
    public bool isUFO;

    private float currentSpawnRate;
    private float nextSpawnTime = 0.0f;

    public float xDir = 0;
    public float yDir = 0;
    public float zDir = -1;


    void Start()
    {
        currentSpawnRate = initialSpawnRate;
    }

    void Update()
    {
        // Check if it's time to spawn a new asteroid
        if (Time.time >= nextSpawnTime)
        {
            SpawnAsteroid();
            CalculateNextSpawnTime();
        }
    }

    void SpawnAsteroid()
    {
        float spawnX = Random.Range(-spawnRangeX, spawnRangeX);

        int xRandom = Random.Range(-1, 1);

        if (spawnInGroup)
        {
            for (int i = -1; i <= 1; i += 1)
            {
                Vector3 spawnPosition = new Vector3(spawnX + i, spawnHeight, transform.position.z + Mathf.Abs(i));

                GameObject asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.Euler(new Vector3(0, 180, 0)));
                EnemyMover mover = asteroid.AddComponent<EnemyMover>();
                mover.translation = new Vector3(xDir*xRandom, yDir, zDir);
                mover.speed = moverSpeed;
            }
        }
        else
        {
            Vector3 spawnPosition = new Vector3(spawnX, spawnHeight, transform.position.z);

            GameObject asteroid;


            if (isUFO)
            {
                spawnPosition = new Vector3(transform.position.x, spawnHeight, transform.position.z + spawnX);
                asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else
            {
                asteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.Euler(new Vector3(0, 180, 0)));
            }
            EnemyMover mover = asteroid.AddComponent<EnemyMover>();
            mover.translation = new Vector3(xDir, yDir, zDir);
            mover.speed = moverSpeed;
        }
    }

    void CalculateNextSpawnTime()
    {
        // Gradually decrease the spawn rate
        currentSpawnRate = Mathf.Max(currentSpawnRate - spawnRateDecrease, minSpawnRate);

        // Calculate the next spawn time using the current spawn rate
        nextSpawnTime = Time.time + currentSpawnRate;
    }
}
