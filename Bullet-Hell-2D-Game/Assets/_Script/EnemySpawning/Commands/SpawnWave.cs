﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWave : Command {
    // Array with the spawn locations for enemies
    private GameObject[] spawnPositions;

    // Prefab of enemy to spawn
    private GameObject enemyPrefab;

    // Each entry in the array must be a 0 or 1
    // 0 meaning not to spawn and 1 meaning to spawn
    // There must be an entry in the array for each entry in spawnPositions
    private int[] spawnAtPositions;

    // Time to wait until before starting the next command
    private float endTime;

    private bool isWaveSpawned = false;
    private bool isFinished = false;

    // The contructor below will save the parameters for the command upon initializing it
    public SpawnWave(GameObject[] spawnPositions, GameObject enemyPrefab, int[] spawnAtPositions, float delay) {
        this.spawnPositions = spawnPositions;
        this.enemyPrefab = enemyPrefab;
        this.spawnAtPositions = spawnAtPositions;
        endTime = Time.time + delay;
    }

    public void RunCommand() {
        SpawnEnemies();

        if (Time.time > endTime) {
            isFinished = true;
        }
    }

    private void SpawnEnemies() {
        // Check if enemies need to be spawned yet
        if(isWaveSpawned) {
            return;
        }

        try {
            for (int i = 0; i < spawnPositions.Length; i++) {
                // Check if an enemy should spawn at this position
                if (spawnAtPositions[i] == 1) {
                    // If it should, spawn the enemy at this position with the prefab's rotation
                    UnityEngine.Object.Instantiate(enemyPrefab, spawnPositions[i].transform.position, enemyPrefab.transform.rotation);
                }
            }
            isWaveSpawned = true;
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