using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerController : MonoBehaviour {

    public GameObject player;
    public GameObject anim;
    public GameObject explosion;

    private Renderer rend;

    private bool isPicked = false;


    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        // Destroy if not picked and has fallen through level
        if (!isPicked)
        {
            if (!rend.isVisible && transform.position.y < 0)
            {
                Destroy(gameObject);
            }
        }
    }


    // Player picks up powerup
    public void OnMouseDown()
    {
        // Get controller of player
        PlayerController playerController = player.GetComponent<PlayerController>();

        // If player has powerup destroy it
        if (playerController.powerUp)
        {
            Destroy(playerController.powerUp);
        }
        // Assign as powerup
        playerController.powerUp = this;

        // Show explosion on pickup
        Instantiate(explosion, transform.position, transform.rotation);
        // Hide itself
        transform.position = new Vector3(transform.position.x, transform.position.y, -6f);
        isPicked = true;
    }

    protected void Resume()
    {
        Destroy(anim);
        Destroy(gameObject);
    }

    // Do the power up
    public virtual void UsePower(bool hitLeft)
    {

    }
}
