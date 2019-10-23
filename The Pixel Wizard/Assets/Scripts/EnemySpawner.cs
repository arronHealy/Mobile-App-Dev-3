using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField] List<WaveConfig> waveConfigs;

    int startingWave = 0;

	// Use this for initialization
	void Start () {
        var currentWave = waveConfigs[startingWave];
        SpawnEnemy(waveConfigs[startingWave + 1]);
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
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

    private void SpawnEnemy(WaveConfig waveConfig)
    {
        Instantiate(waveConfig.GetEnemyPrefab(),
            waveConfig.GetWaypoints()[1].transform.position,
            Quaternion.identity);
    }
}
