using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : PowerController
{
    // Do the power up
    public override void UsePower(bool hitLeft)
    {
        Debug.Log("HI!");
        // Get all enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // Hit all enemies on chosen side once
        foreach (GameObject enemy in enemies)
        {
            if (hitLeft && enemy.transform.position.x < 0)
            {
                EnemyController enemyController = enemy.GetComponent<EnemyController>();
                enemyController.GetHit();
            }
            else if (!hitLeft && enemy.transform.position.x > 0)
            {
                EnemyController enemyController = enemy.GetComponent<EnemyController>();
                enemyController.GetHit();
            }
        }
        // Delete itself
        Destroy(gameObject);
    }
}
