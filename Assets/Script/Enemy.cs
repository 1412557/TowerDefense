using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    // Use this for initialization

    public float StartSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float health = 100f;

    public int value = 9;
    public GameObject DeathEffect;

    void Start()
    {
        speed = StartSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -=amount;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Slow(float rate)
    {
        speed = StartSpeed*(1f - rate);
    }

    private void Die()
    {
        PlayerStat.money += value;

        GameObject effect = (GameObject)Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }


}
