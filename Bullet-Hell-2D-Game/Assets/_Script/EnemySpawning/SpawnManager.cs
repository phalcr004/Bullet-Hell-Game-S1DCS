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

        // BELOW IS AN EXAMPLE OF WHY I NEED TO CHANGE THIS OR SOMETHING (I KIND OF HAVE AN IDEA)
        commands.Enqueue(new DelayNextCommand(Time.time, 1f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 1, 0, 0, 0, 0, 0, 0 }, 1.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 1, 0, 0, 0, 0, 0 }, 2f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 1, 0, 0, 0, 0 }, 2.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 1, 0, 0, 0 }, 3f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 0, 1, 0, 0 }, 3.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 0, 0, 1, 0 }, 4f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 0, 0, 0, 1 }, 4.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 0, 0, 1, 0 }, 5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 0, 1, 0, 0 }, 5.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 1, 0, 0, 0 }, 6f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 1, 0, 0, 0, 0 }, 6.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 1, 0, 0, 0, 0, 0 }, 7f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 1, 0, 0, 0, 0, 0, 0 }, 7.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 1, 0, 0, 0, 0, 0 }, 8f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 1, 0, 0, 0, 0 }, 8.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 1, 0, 0, 0 }, 9f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 0, 1, 0, 0 }, 9.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 0, 0, 1, 0 }, 10f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 0, 0, 0, 1 }, 10.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 0, 0, 1, 0 }, 11f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 0, 1, 0, 0 }, 11.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 1, 0, 0, 0 }, 12f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 1, 0, 0, 0, 0 }, 12.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 1, 0, 0, 0, 0, 0 }, 13f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 1, 0, 0, 0, 0, 0, 0 }, 13.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 1, 0, 0, 0, 0, 0 }, 14f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 1, 0, 0, 0, 0 }, 14.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 1, 0, 0, 0 }, 15f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 0, 1, 0, 0 }, 15.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 0, 0, 1, 0 }, 16f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 0, 0, 0, 1 }, 16.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 0, 0, 1, 0 }, 17f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 0, 1, 0, 0 }, 17.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 0, 1, 0, 0, 0 }, 18f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 0, 1, 0, 0, 0, 0 }, 18.5f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 0, 1, 0, 0, 0, 0, 0 }, 19f));
        commands.Enqueue(new SpawnWave(spawnPositions, testEnemy1, new int[] { 1, 0, 0, 0, 0, 0, 0 }, 19.5f));
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
