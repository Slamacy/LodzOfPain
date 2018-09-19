using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArthurController : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        Invoke("KillMe", 2.2f);
    }

    private void KillMe()
    {
        Destroy(gameObject);
    }
}
