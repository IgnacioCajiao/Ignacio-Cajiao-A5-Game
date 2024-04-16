using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;
    public float spawnRate = 2.0f;
    public int spawnCount = 1;
    public float spawnDistance = 15.0f;
    public float trajectoryVar = 15.0f;
    
    // this calls the spawn function repeatedly with a delay
    void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }
    // this spawns the asteroids with a random spawn direction and point,and creates a rotation with an random variance.
    // also makes asteroid a random size between minSize and maxSize
    // and trajectory is set to opposite of spawn direction
    private void Spawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitSphere.normalized * spawnDistance;
            Vector3 spawnPoint = transform.position + spawnDirection;
            
            float variance = Random.Range(-trajectoryVar, trajectoryVar);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            
            Asteroid asteroid = Instantiate(asteroidPrefab, spawnPoint, rotation);

            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }
    }
}
