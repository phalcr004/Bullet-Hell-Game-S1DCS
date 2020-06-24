using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWaveStaggered : ICommand {
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

    // The column index needs to be saved between method calls
    private int columnIndex = 0;

    private bool isFinished = false;

    // The contructor below will save the parameters for the command upon initializing it
    public SpawnWaveStaggered(GameObject[] spawnPositions, GameObject enemyPrefab, int[,] spawnAtPositions, float startTime, float waveDelay) {
        this.spawnPositions = spawnPositions;
        this.enemyPrefab = enemyPrefab;
        this.spawnAtPositions = spawnAtPositions;
        this.startTime = startTime;
        this.waveDelay = waveDelay;
        this.nextSpawnTime = Time.time + waveDelay;
    }

    public void RunCommand() {
        // Wait until the time specified before spawning enemies
        if(Time.time > startTime) {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies() {
        // Return if the next wave isn't ready to spawn
        if(Time.time < nextSpawnTime) {
            return;
        }

        // Try catch ensures that the program will continue to run even if the command is input incorrectly
        try { 
            // For each 
            for(int rowIndex = 0; rowIndex < spawnPositions.Length; rowIndex++) {
                if(spawnAtPositions[columnIndex, rowIndex] == 1) {
                    UnityEngine.Object.Instantiate(enemyPrefab, spawnPositions[rowIndex].transform.position, spawnPositions[rowIndex].transform.rotation);
                }
            }
            // Increment the index and set the time for the next wave to spawn
            columnIndex++;
            nextSpawnTime = Time.time + waveDelay;
        }
        catch (IndexOutOfRangeException e) {
            // If an array is less than the required length, catch the error and keep the game running
            Debug.LogWarning("Index out of bounds of array. Continuing game.");
        }
    }

    public bool CheckIsFinished() {
        // If the index is greater than or equal to the length, there should be no more enemies to spawn (arrays start at 0)
        if(columnIndex >= spawnAtPositions.GetLength(0)) {
            isFinished = true;
        }
        return isFinished;
    }
}
