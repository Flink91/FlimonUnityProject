using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyAgentPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 8f;
		public float timeBetweenEnemies = 0.1f;
    private float countdown = 5f;
    public Text waveCountdownText;
    private int waveIndex = 0;


		void Start(){
					Debug.Log("SpawnEnemy");
					Instantiate(enemyAgentPrefab, spawnPoint.position, spawnPoint.rotation);
		}
    void Update(){
       if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
		} 
        countdown -= Time.deltaTime;

		waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave ()
	{
		waveIndex++;

		for (int i = 0; i < waveIndex; i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(timeBetweenEnemies);
		}
	}

    void SpawnEnemy ()
	{
		Debug.Log("SpawnEnemy"+ enemyAgentPrefab +""+ spawnPoint.position);
		var newEnemy = Instantiate(enemyAgentPrefab, spawnPoint.position, spawnPoint.rotation);
        newEnemy.transform.parent = GameObject.Find("Enemies").transform;
	}

}
