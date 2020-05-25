using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWaveStaggered : Command {
    // Array with the spawn locations for enemies
    private GameObject[] spawnPositions;

    // Prefab of enemy to spawn
    private GameObject enemyPrefab;

    // Each entry in the array must be a 0 or 1
    // 0 meaning not to spawn and 1 meaning to spawn
    // There must be an entry in the array for each entry in spawnPositions
    // 
    private int[,] spawnAtPositions;

    // Time to wait until before starting to spawn waves
    private float startTime;

    // Time between each wave
    private float waveDelay;
    private float nextSpawnTime;

    private int index;

    private bool isFinished = false;

    // The contructor below will save the parameters for the command upon initializing it
    public SpawnWaveStaggered(GameObject[] spawnPositions, GameObject enemyPrefab, int[,] spawnAtPositions, float startTime, float waveDelay) {
        this.spawnPositions = spawnPositions;
        this.enemyPrefab = enemyPrefab;
        this.spawnAtPositions = spawnAtPositions;
        this.startTime = startTime;
        this.waveDelay = waveDelay;
    }

    public void RunCommand() {
        if (Time.time > startTime) {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies() {
        Debug.Log("Code hasn't failed yet");
        isFinished = true;
        try { 
            
        }
        catch (IndexOutOfRangeException e) {
            // If an array is less than the required length, catch the error and keep the game running
            Debug.LogError("Index out of bounds of array. Continuing game.");
        }
        
    }

    public bool CheckIsFinished() {
        return isFinished;
    }
}
