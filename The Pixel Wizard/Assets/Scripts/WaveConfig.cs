﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject {

    [SerializeField] GameObject enemyPrefab;
    
    // [SerializeField] GameObject pathPrefab;

    [SerializeField] float timeBetweenSpawns = 3f;

    [SerializeField] float spawnRandom = 0.3f;

    [SerializeField] int numOfEnemies = 2;

    [SerializeField] float moveSpeed = 1f;

    /*
    * ScriptableObject type allows for saving of use of data independent of class instances 
    * Type mainly used for creating of enemies and time delays
    */

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    /*
    public List<Transform> GetWaypoints()
    {
        var waveWayPoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;
    }
    */
    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandom()
    {
        return spawnRandom;
    }

    public int GetNumOfEnemies()
    {
        return numOfEnemies;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
