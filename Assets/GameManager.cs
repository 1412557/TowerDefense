using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool gameOver = false;
	// Update is called once per frame
	void Update () {
        if (gameOver)
            return;

		if (PlayerStat.lives <= 0)
        {
            EndGame();
        }
	}

    private void EndGame()
    {
        gameOver = true;
    }
}
