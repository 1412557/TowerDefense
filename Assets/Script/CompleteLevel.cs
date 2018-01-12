using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour {

    // Use this for initialization
    public string menuScene = "mainmenu";
    public SceneFader fader;

    public string nextLevel = "scene2";
    public int levelReached = 2;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelReached);
        fader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        fader.FadeTo(menuScene);
    }
}
