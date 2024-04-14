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
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

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
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
