using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour {

    // Use this for initialization
    public static int money;
    public int startMoney = 1000;

    public static int lives;
    public static int StartLives = 50;

    public static int Rounds;

    void Start (){
        money = startMoney;
        lives = StartLives;
        Rounds = 0;
    }
}
