using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int startingHP;
    public GameObject hitRanger;    //  Indicates the range of the players strikes
    public PowerController powerUp;      // Special attack
    public GameObject endScreen;

    private int currentHP;

	// Use this for initialization
	void Start () {
        currentHP = startingHP;

        // Get controller of players hit ranger
        powerUp = null;
    }

    // Call when hp is zero or player chooses to quit the game
    public void EndGame()
    {
        Instantiate(endScreen);
        Time.timeScale = 0;
    }

    public void GetHit()
    {
        currentHP -= 1;
        if (currentHP <= 0)
        {
            EndGame();
        }
    }
}
