using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start() {
        if (transform.position.x > 0)
        {
            speed *= -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit player");
        }
        else if (other.gameObject.tag == "Animation")
        {
            Debug.Log("Start punching animation");
        }
    }
}
