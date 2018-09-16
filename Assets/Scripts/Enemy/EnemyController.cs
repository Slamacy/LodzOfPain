using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;

    private GameObject hitRanger;
    private bool isDone;

    // Use this for initialization
    void Start()
    {
        if (transform.position.x > 0)
        {
            speed *= -1;
        }
        isDone = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isDone)
        {
            // Move to player in given speed
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        else
        {
            // Run away in a random pattern
            transform.position = new Vector3(transform.position.x + Random.Range(-0.3f, 0.3f), transform.position.y - Random.Range(0.1f, 0.3f), transform.position.z);

            // When out of screen destroy this object
            if (!GetComponent<Renderer>().isVisible)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (hitRanger)
            {
                // Get controller and hit player
                HitRangerController hitController = hitRanger.GetComponent<HitRangerController>();
                hitController.HitPlayer(this);
                isDone = true;
            }
        }
        else if (other.gameObject.tag == "Animation")
        {
            // Grab the reference of hit ranger to be able to hit the player
            hitRanger = other.gameObject;

            Debug.Log("Start punching animation");
        }
    }
}
