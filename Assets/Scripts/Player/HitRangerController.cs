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
	
	// Update is called once per frame
	void Update ()
    {
		
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
        if (hitLeft)
        {

        }
        else
        {

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
