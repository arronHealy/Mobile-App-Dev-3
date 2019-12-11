using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemySpawner : MonoBehaviour
{

    [SerializeField] WaveConfig enemyWaveConfig;

    int startingWave = 0;

    [SerializeField] int enemies = 0;

    // Use this for initialization
    void Start()
    {
        //var currentWave = waveConfigs[startingWave];
        //StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        StartCoroutine(RandomSpawn(enemyWaveConfig));
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
    }
}