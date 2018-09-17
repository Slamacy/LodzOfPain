using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int startingHP;
    public GameObject hitRanger;    //  Indicates the range of the players strikes
    public PowerController powerUp;      // Special attack


    private HitRangerController rangerController;

    private int currentHP;
    private int score;

	// Use this for initialization
	void Start () {
        currentHP = startingHP;
        score = 0;

        // Get controller of players hit ranger
        rangerController = hitRanger.GetComponent<HitRangerController>();
        powerUp = null;
    }

    // Call when hp is zero or player chooses to quit the game
    private void EndGame()
    {
        Debug.Log("END");
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
