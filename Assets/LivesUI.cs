using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

    // Use this for initialization
    public Text livesText;
	public Image hpBarFill;
	
	// Update is called once per frame
	void Update () {
        livesText.text = PlayerStat.lives.ToString();
		float amount = PlayerStat.lives / PlayerStat.StartLives;
		hpBarFill.fillAmount = amount;
	}
}
