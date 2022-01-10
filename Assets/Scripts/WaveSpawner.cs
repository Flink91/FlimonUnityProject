using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

	public static int EnemiesAlive = 0;

	public Wave[] waves;

	public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
	public float timeBetweenEnemies = 0.1f;

    private float countdown = 5f;
    public Text waveCountdownText;

	public GameManager gameManager;

	private int waveIndex = 0;


    void Update(){
		if (EnemiesAlive > 0)
		{
			return;
		}
		if (waveIndex == waves.Length)
		{
			gameManager.WinLevel();
			this.enabled = false;
		}
		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
		} 
        countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity); 

		waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

	IEnumerator SpawnWave()
	{
		PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}

		waveIndex++;
	}

	void SpawnEnemy (GameObject enemy)
	{
		//randomize spawn point a bit
		float rnd = Random.Range(-2.0f, 2.0f);
		Vector3 spawnPos = new Vector3 (spawnPoint.position.x + rnd, spawnPoint.position.y + rnd, spawnPoint.position.z);

		var newEnemy = Instantiate(enemy, spawnPos, spawnPoint.rotation);
        newEnemy.transform.parent = GameObject.Find("Enemies").transform;
		EnemiesAlive++;
	}

}
