using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemySpawner : MonoBehaviour
{

    [SerializeField] WaveConfig enemyWaveConfig;

    [SerializeField] int enemies = 0;

    // Use this for initialization
    void Start()
    {
        // start coroutine to spawn the big enemies
        StartCoroutine(RandomSpawn(enemyWaveConfig));
    }

    private IEnumerator RandomSpawn(WaveConfig waveConfig)
    {
        // loop for number of enemies and spawn randomly in relation to game object
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