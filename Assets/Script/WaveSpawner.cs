using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public Text WaveCountDown;
	public Text WaveNumber;
	public float LevelPrepareTime = 20f;
    public float timeBetweenWaves = 5f;
	private float countDown;

    public GameManager gameManager;
    private int waveNumber = 0;

	void Start()
	{
		countDown = LevelPrepareTime;
	}
		

    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        if (waveNumber == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            //return;
        }
		countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

		WaveCountDown.text = string.Format("{0:00}", Math.Floor(countDown));
		WaveNumber.text = string.Format ("Wave No: {0}", waveNumber);
    }

    IEnumerator SpawnWave()
    {
        PlayerStat.Rounds++;
        FindObjectOfType<AudioManager>().Play("WaveStart");

        Wave wave = waves[waveNumber];
        EnemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        waveNumber++;
        
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
