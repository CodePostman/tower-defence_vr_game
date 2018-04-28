﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Wave[] Waves; // class to hold information per wave
    public Transform SpawnPoint;
    public float TimeBetweenEnemies = 2.0f;
    public float TimeBetweenWaves = 4.0f;

    private int _totalEnemiesInCurrentWave;
    private int _enemiesInWaveLeft;
    private int _spawnedEnemies;

    private int _currentWave;
    private int _totalWaves;

    void Start()
    {
        _currentWave = -1; // avoid off by 1
        _totalWaves = Waves.Length - 1; // adjust, because we're using 0 index

        StartNextWave();
    }

    void StartNextWave()
    {
        _currentWave++;

        // win
        if (_currentWave > _totalWaves)
        {
            return;
        }

        _totalEnemiesInCurrentWave = Waves[_currentWave].EnemiesPerWave;
        _enemiesInWaveLeft = 0;
        _spawnedEnemies = 0;

        StartCoroutine(SpawnEnemies());
    }

    // Coroutine to spawn all of our enemies
    IEnumerator SpawnEnemies()
    {
        GameObject enemy = Waves[_currentWave].Enemy;
        while (_spawnedEnemies < _totalEnemiesInCurrentWave)
        {
            _spawnedEnemies++;
            _enemiesInWaveLeft++;

            //int spawnPointIndex = Random.Range(0, SpawnPoints.Length);

            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(enemy, SpawnPoint.position, SpawnPoint.rotation);
            yield return new WaitForSeconds(TimeBetweenEnemies);
        }
        yield return null;
    }

    // called by an enemy when they're defeated
    public void EnemyDefeated()
    {
        _enemiesInWaveLeft--;

        // We start the next wave once we have spawned and defeated them all
        if (_enemiesInWaveLeft == 0 && _spawnedEnemies == _totalEnemiesInCurrentWave)
        {
            StartCoroutine(BetweenWaves());
        }
    }

    IEnumerator BetweenWaves()
    {
        yield return new WaitForSeconds(TimeBetweenWaves);
        StartNextWave();
    }
}