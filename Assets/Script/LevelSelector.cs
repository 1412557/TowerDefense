using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public SceneFader fader;
    public Button[] btn;
	// Use this for initialization
    void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached",1);
        for(int i = 0; i < btn.Length; i++)
        {
            if(i+1>levelReached)
                btn[i].interactable = false;
        }
    }

	public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }
}
