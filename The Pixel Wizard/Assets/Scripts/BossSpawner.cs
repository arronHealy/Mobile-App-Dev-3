using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour {

    [SerializeField] WaveConfig waveConfig;

	public void SpawnBoss()
    {
        Instantiate(
            waveConfig.GetEnemyPrefab(),
            gameObject.transform.position,
            Quaternion.identity
            );
    }
}
