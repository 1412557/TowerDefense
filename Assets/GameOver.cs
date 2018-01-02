using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    // Use this for initialization
    public Text roundsText;

    public SceneFader sceneFader;

    public string MenuSceneName = "mainmenu";

    void OnEnable()
    {
        roundsText.text = PlayerStat.Rounds.ToString();
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader.FadeTo(MenuSceneName);
    }
}
