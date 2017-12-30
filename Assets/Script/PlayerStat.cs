using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour {

    // Use this for initialization
    public static int money;
    public int startMoney = 1000;

    void Start (){
        money = startMoney;
    }
}
