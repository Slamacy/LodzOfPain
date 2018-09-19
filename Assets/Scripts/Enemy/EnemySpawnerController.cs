using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour {

    public GameObject enemy1;
    public GameObject enemy2;

    public int enemy1Ratio;
    public int enemy2Ratio;

    public float spawnTime;
    public float spawnTimeChange;

    public float enemySpeed;
    public float enemySpeedChange;

    public int diffucultyInterval;

    private int count = 0;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime
        Invoke("Spawn", 2 + Random.Range(0f, 0.5f));
    }


    void Spawn()
    {
        // Create an instance of the enemy prefab at the spawn point's position
        GameObject clone;
        float random = Random.Range(1f, enemy1Ratio + enemy2Ratio);
        if(random <= enemy1Ratio)
        {
            clone = Instantiate(enemy1, transform.position, transform.rotation);
        }
        else /* if (random <= enemy1Ratio + enemy2Ratio) */
        {
            clone = Instantiate(enemy2, transform.position, transform.rotation);
        }

        // Get controller of spawned enemy
        EnemyController cloneController = clone.GetComponent<EnemyController>();

        // Do things to enemy (speed, different sprites and hp and etc.)
        cloneController.speed = enemySpeed + Random.Range(0f, enemySpeedChange);
        // Increment counter for spawns
        count++;

        // Increase difficulty after a certain amount of enemies have spawned
        if (count % diffucultyInterval == 0)
        {
            spawnTime -= spawnTimeChange;
            // Cap spawn time and 0.15s
            if (spawnTime < 0.15)
                spawnTime = 0.15f;
            // Cap enemy speed at 0.3
            enemySpeed += enemySpeedChange;
            if (enemySpeed > 0.3)
                enemySpeed = 0.3f;
        }

        // Call the Spawn function after a delay of the spawnTime.
        Invoke("Spawn", spawnTime - Random.Range(0f, spawnTimeChange));
    }
}
