using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string levelToLoad = "mainscene";

    public SceneFader sceneFader;
	// Use this for initialization
	public void Play () {
        sceneFader.FadeTo(levelToLoad);
	}
	
	// Update is called once per frame
	public void Exit()
    {
        Application.Quit();
    }
}
