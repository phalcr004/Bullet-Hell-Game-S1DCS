using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    // Create a first-in first-out queue to hold commands for this level
    private Queue<ICommand> commands = new Queue<ICommand>();

    // All prefabs for enemies
    [SerializeField] GameObject testEnemy1;

    // Three spawn zones (top, bottom, right side)
    [SerializeField] GameObject[] topSpawnPositions;
    [SerializeField] GameObject[] bottomSpawnPositions;
    [SerializeField] GameObject[] backSpawnPositions;

    void Start() {
        // Add all the commands for this level below
        commands.Enqueue(new SpawnWaveStaggered(backSpawnPositions, testEnemy1, new int[,] { { 0, 0, 0, 1, 0, 0, 0 }, { 0, 1, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 1, 0 }, { 1, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 1 } }, 3f, 0.5f));
        commands.Enqueue(new SpawnWaveStaggered(topSpawnPositions, testEnemy1, new int[,] { { 0, 0, 0, 1, 0, 0, 0 }, { 0, 1, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 1, 0 }, { 1, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 1 } }, 5f, 0.5f));
        commands.Enqueue(new SpawnWaveStaggered(bottomSpawnPositions, testEnemy1, new int[,] { { 0, 0, 0, 1, 0, 0, 0 }, { 0, 1, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 1, 0 }, { 1, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 1 } }, 7f, 0.5f));
    }

    void Update() {
        // Check if there are no commands left
        if(commands.Count == 0) {
            //Turn off spawn managaer
            gameObject.SetActive(false);
            return;
        }
        // Look at the first command in the queue
        ICommand currentCommand = commands.Peek();

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

public interface ICommand {
    // Interface ensures every "command" has these methods
    void RunCommand();
    bool CheckIsFinished();
}
