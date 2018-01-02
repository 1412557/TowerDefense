using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    // Use this for initialization

    public float StartSpeed = 10f;

    [HideInInspector]
    public float speed;

    public float startHealth = 100f;
    private float health;

    public int value = 9;
    public GameObject DeathEffect;

    [Header("Unity stuff")]
    public Image healthBar;

    void Start()
    {
        health = startHealth;
        speed = StartSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -=amount;
        healthBar.fillAmount = health / startHealth;
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
