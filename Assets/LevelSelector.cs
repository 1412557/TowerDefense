using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour {

    public SceneFader fader;
	// Use this for initialization
	public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }
}
