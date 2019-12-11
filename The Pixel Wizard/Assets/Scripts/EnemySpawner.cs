﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] WaveConfig enemyWaveConfig;

    int startingWave = 0;
    
    [SerializeField] int enemies = 0;

	// Use this for initialization
	void Start () {
        //var currentWave = waveConfigs[startingWave];
        //StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        StartCoroutine(RandomSpawn(enemyWaveConfig));
	}

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

    private IEnumerator RandomSpawn(WaveConfig waveConfig)
    {
        
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

    private void spawnBoss()
    {
        FindObjectOfType<BossSpawner>().SpawnBoss();
    }
}
