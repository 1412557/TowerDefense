using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject gameOverUI;

    public static bool GameIsOver;
	// Update is called once per frame

    void Start()
    {
        GameIsOver = false;
    }

	void Update () {
        if (GameIsOver)
            return;

		if (PlayerStat.lives <= 0)
        {
            EndGame();
        }
	}

    private void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
