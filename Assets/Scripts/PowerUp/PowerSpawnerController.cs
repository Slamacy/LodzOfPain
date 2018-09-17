using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawnerController : MonoBehaviour
{
    public GameObject player;

    public GameObject powerUp1;
    public GameObject powerUp2;

    public int powerUp1Ratio;
    public int powerUp2Ratio;

    public float spawnTime;
    public float spawnTimeChange;

    private int count;
    public int diffucultyInterval;

    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime
        Invoke("Spawn", spawnTime - Random.Range(0f, spawnTimeChange));
    }


    void Spawn()
    {
        // Create an instance of the enemy prefab at the spawn point's position
        GameObject clone;
        float random = Random.Range(1f, powerUp1Ratio + powerUp2Ratio);
        if (random <= powerUp1Ratio)
        {
            clone = Instantiate(powerUp1, transform.position, transform.rotation);
        }
        else /* if (random <= enemy1Ratio + enemy2Ratio) */
        {
            clone = Instantiate(powerUp2, transform.position, transform.rotation);
        }
        count++;

        // Get controller of spawned powerup
        PowerController powerController = clone.GetComponent<PowerController>();

        // Assign player to powerup
        powerController.player = player;

        // Increase spawns as the game gets harder
        if (count % diffucultyInterval == 0)
        {
            spawnTime -= spawnTimeChange;
            // Cap spawn time on 0.50s
            if (spawnTime < 0.50)
                spawnTime = 0.50f;  
        }

        // Call the Spawn function after a delay of the spawnTime.
        Invoke("Spawn", spawnTime - Random.Range(0f, spawnTimeChange));
    }
}
