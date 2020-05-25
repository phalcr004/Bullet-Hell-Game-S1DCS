using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    // Create a first-in first-out queue to hold commands for this level
    private Queue<Command> commands = new Queue<Command>();

    // All prefabs for enemies
    [SerializeField] GameObject testEnemy1;
    [SerializeField] GameObject testEnemy2;
    [SerializeField] GameObject[] spawnPositions;

    void Start() {
        // Add all the commands for this level below

        //commands.Enqueue(new SpawnWaveStaggered(spawnPositions, testEnemy1, new int[,] { { 1, 0, 1, 0, 1, 0, 1 }, { 0, 1, 0, 1, 0, 1, 0 } }, 3f, 10f));

    }

    public void AddTriangleFormation(GameObject enemyPrefab, float startTime, float delay) {
        commands.Enqueue(new SpawnWave(spawnPositions, enemyPrefab, new int[] { 0, 0, 0, 1, 0, 0, 0 }, startTime));
        commands.Enqueue(new SpawnWave(spawnPositions, enemyPrefab, new int[] { 0, 0, 1, 0, 1, 0, 0 }, startTime + (delay * 1)));
        commands.Enqueue(new SpawnWave(spawnPositions, enemyPrefab, new int[] { 0, 1, 0, 0, 0, 1, 0 }, startTime + (delay * 2)));
        commands.Enqueue(new SpawnWave(spawnPositions, enemyPrefab, new int[] { 1, 0, 0, 0, 0, 0, 1 }, startTime + (delay * 3)));
    }

    public void AddInverseTriangleFormation(GameObject enemyPrefab, float previousDelay, float delay) {
        commands.Enqueue(new SpawnWave(spawnPositions, enemyPrefab, new int[] { 1, 0, 0, 0, 0, 0, 1 }, previousDelay + (delay * 1)));
        commands.Enqueue(new SpawnWave(spawnPositions, enemyPrefab, new int[] { 0, 1, 0, 0, 0, 1, 0 }, previousDelay + (delay * 2)));
        commands.Enqueue(new SpawnWave(spawnPositions, enemyPrefab, new int[] { 0, 0, 1, 0, 1, 0, 0 }, previousDelay + (delay * 3)));
        commands.Enqueue(new SpawnWave(spawnPositions, enemyPrefab, new int[] { 0, 0, 0, 1, 0, 0, 0 }, previousDelay + (delay * 4)));
    }

    void Update() {
        // Check if there are no commands left
        if(commands.Count == 0) {
            // Turn off spawn managaer
            gameObject.SetActive(false);
            return;
        }
        // Look at the first command in the queue
        Command currentCommand = commands.Peek();

        // Make sure the command is valid
        if(currentCommand == null) {
            return;
        }

        // Run the RunCommand method from the current command
        currentCommand.RunCommand();
        if(currentCommand.CheckIsFinished()) {
            // If the command is finished, remove it from the queue
            commands.Dequeue();
        }
    }
}

public interface Command {
    void RunCommand();
    bool CheckIsFinished();
}
