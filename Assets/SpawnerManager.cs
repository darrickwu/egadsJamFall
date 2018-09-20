using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    private float spawnTimer;               // Starting time between spawns
    public float startDelay;                // Time before spawning can begin
    public float spawnDecrease;             // How much the spawn time will decrease per second
    public float minSpawnTime;              // Minimum allowed spawn time
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public GameObject[] blockTypes;         // An array of the spawn points this enemy can spawn from.


    void Start()
    {
        spawnTimer = spawnTime;
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        //InvokeRepeating("Spawn", startDelay, spawnTime);
    }

    private void Update()
    {
        if (startDelay <= 0)
        {
            if (spawnTimer > 0)
            {
                spawnTimer -= 1 * Time.deltaTime;
            } else
            {
                Spawn();
                spawnTimer = spawnTime;
            }
        }
    }

    private void FixedUpdate()
    {
        if(startDelay > 0)
        {
            startDelay -= 1 * Time.deltaTime;
        } else if (spawnTime > minSpawnTime)
        {
            spawnTime -= spawnDecrease * Time.deltaTime;
        } else if (spawnTime < minSpawnTime)
        {
            spawnTime = minSpawnTime;
        }
    }


    void Spawn()
    {
        // If the player has no health left...
        //if (playerHealth.currentHealth <= 0f)
        //{
            // ... exit the function.
        //    return;
        //}

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        int pick = Random.Range(0, blockTypes.Length);
        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(blockTypes[pick], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
