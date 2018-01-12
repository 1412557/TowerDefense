using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    // Use this for initialization
    

    public SceneFader sceneFader;

    public string MenuSceneName = "mainmenu";
    

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader.FadeTo(MenuSceneName);
    }
}
