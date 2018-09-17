using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;

    public int startingHP;
    public int currentHP;

    private GameObject hitRanger;
    private bool isDone;
    private Renderer rend;

    // Use this for initialization
    void Start()
    {
        if (transform.position.x > 0)
        {
            speed *= -1;
        }
        isDone = false;
        currentHP = startingHP;
        rend = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isDone && currentHP > 0)
        {
            // Move to player in given speed
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        else if (currentHP > 0)
        {
            // Run away in a random pattern
            transform.position = new Vector3(transform.position.x + Random.Range(-0.3f, 0.3f), transform.position.y - Random.Range(0.1f, 0.3f), transform.position.z);
        }

        if(currentHP <= 0 || isDone)
        {
            // When out of screen destroy this object
            if (!rend.isVisible)
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

            // Debug.Log("Start punching animation");
        }
    }

    public void GetHit()
    {
        currentHP -= 1;

        Rigidbody rb;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(2f, 0f, 0f, ForceMode.Impulse);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    // Call when hp is zero
    private void Die()
    {
        Rigidbody rb;
        rb = GetComponent<Rigidbody>();

        float forceX = 3f + Random.Range(0f, 2f);
        float forceY = 7f + Random.Range(0f, 2f);
        float forceZ = -1f;

        if(speed > 0)
        {
            forceX *= -1;
        }

        rb.useGravity = true;
        rb.AddForce(forceX, forceY, forceZ, ForceMode.Impulse);
    }
}
