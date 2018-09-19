using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {
	// Use this for initialization
	void Start () {
        Invoke("KillMe", 0.2f);
	}

    private void Update()
    {
        transform.Rotate(Vector3.back, 120*Time.deltaTime);
    }

    private void KillMe()
    {
        Destroy(gameObject);
    }
}
