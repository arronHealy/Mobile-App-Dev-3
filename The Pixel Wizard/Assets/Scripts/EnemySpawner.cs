using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] WaveConfig enemyWaveConfig;

    [SerializeField] int enemies = 0;

	// Use this for initialization
	void Start () {
        // start coroutine to randomly spawn enemies
        StartCoroutine(RandomSpawn(enemyWaveConfig));
	}

    /*
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumOfEnemies(); i++)
        {
            var newEnemy = Instantiate(
            waveConfig.GetEnemyPrefab(),
            waveConfig.GetWaypoints()[0].transform.position,
            Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
    */

    private IEnumerator RandomSpawn(WaveConfig waveConfig)
    {
        // loop for number of enemies and spawn randomly in relation to spawner game object
        for (int i = 0; i < enemies; i++)
        {
            float spawnX = Random.Range(gameObject.transform.position.x - 10, gameObject.transform.position.x);
            float spawnY = Random.Range(gameObject.transform.position.y, gameObject.transform.position.y + 10);

            Vector3 spawnPos = new Vector3(spawnX, spawnY);

            var newEnemy = Instantiate(
            waveConfig.GetEnemyPrefab(),
            spawnPos,
            Quaternion.identity);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }

        spawnBoss();
    }

    // spawn boss once all enemies created
    private void spawnBoss()
    {
        // find and call boss spawner method
        FindObjectOfType<BossSpawner>().SpawnBoss();
    }
}
