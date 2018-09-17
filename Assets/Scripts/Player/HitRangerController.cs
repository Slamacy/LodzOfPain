using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRangerController : MonoBehaviour {

    private List<GameObject> left;     // Holds enemies on the left
    private List<GameObject> right;    // Holds enemies on the right

    public GameObject player;
    private PlayerController playerController;

	// Use this for initialization
	void Start ()
    {
        left = new List<GameObject>();
        right = new List<GameObject>();

        // Get the player controller
        playerController = player.GetComponent<PlayerController>();
    }

    // As enemies enter range, list them for the correct side
    private void OnTriggerEnter(Collider other)
    {
        GameObject enemy = other.gameObject;
        if (enemy.tag == "Enemy")
        {
            if (enemy.transform.position.x < 0)
            {
                left.Add(enemy);
            }
            else if (enemy.transform.position.x > 0)
            {
                right.Add(enemy);
            }
        }
    }

    // Hits the clossest enemy on the chosen side
    public void HitEnemy(bool hitLeft)
    {
        // Check for super power
        if (playerController.powerUp)
        {
            // Get controller of players hit ranger
            PowerController powerController = playerController.powerUp.GetComponent<PowerController>();
            powerController.UsePower(hitLeft);
            playerController.powerUp = null;
            return;
        }
        // Get correct enemies
        List<GameObject> list = right;
        if (hitLeft)
        {
            list = left;
        }
        // If no enemy leave function
        if (list.Count == 0)
        {
            return;
        }
        GameObject enemy = list[0];

        // Get controller of enemy
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        enemyController.GetHit();
        // Hit player and  remove if hp is zero
        if (enemyController.currentHP <= 0)
        {
            list.Remove(enemy);
        }
    }

    public void HitPlayer(EnemyController enemy)
    {
        playerController.GetHit();

        if (enemy.transform.position.x < 0)
        {
            left.Remove(enemy.gameObject);
        }
        else if (enemy.transform.position.x > 0)
        {
            right.Remove(enemy.gameObject);
        }  
    }
}
