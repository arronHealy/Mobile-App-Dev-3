using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
// spawn enemies at different spawn points

public class PointSpawner : MonoBehaviour
{
    
    // == Private fields ==
    // need a prefab to spawn 
    [SerializeField]
    private Enemy enemyPrefab;

    private float spawnDelay = 1.0f;

    private float spawnInterval = 0.5f;

    private IList<SpawnPoint> spawnPoints;

    // create a variable for the parent object of enemies.
    // name that "EnemyParent"
    private GameObject enemyParent;

    // Start is called before the first frame update
    void Start()
    {
        // get the enemy parent object
        enemyParent = ParentUtils.GetEnemyParent();

        // need to get a list of spawn points
        spawnPoints = GetComponentsInChildren<SpawnPoint>();
        SpawnRepeating();
    }

    // invokeRepeating
    private void SpawnRepeating()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnInterval);
    }

    // spawn a single enemy ship
    private void Spawn()
    {
        var randomIndex = Random.Range(0, spawnPoints.Count);
        var currPoint = spawnPoints[randomIndex];

        //var enemy = Instantiate(enemyPrefab); // add to the hierarchy base level
        var enemy = Instantiate(enemyPrefab, enemyParent.transform);
        enemy.transform.position = currPoint.transform.position;
    }

}
