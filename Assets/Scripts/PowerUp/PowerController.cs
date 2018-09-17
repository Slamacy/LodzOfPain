using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour {

    public GameObject player;

    // Player picks up powerup
    public void OnMouseDown()
    {
        // Get controller of player
        PlayerController playerController = player.GetComponent<PlayerController>();
        playerController.powerUp = this;
        // Hide itself
        transform.position = new Vector3(transform.position.x, transform.position.y, -6f);

        Debug.Log("Picked it up");
    }

    // Do the power up
    public virtual void UsePower(bool hitLeft)
    {

    }
}
