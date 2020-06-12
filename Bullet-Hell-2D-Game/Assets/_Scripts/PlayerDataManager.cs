using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerDataManager : MonoBehaviour {
    private string path;
    private string jsonString;

    public PlayerData playerData;
    void Start() {
        // Read in the json file
        path = Application.streamingAssetsPath + "/player-data.JSON";
        jsonString = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<PlayerData>(jsonString);
    }

    public void OverwriteJsonFile() {
        JsonUtility.ToJson(playerData);
    }

    public void UpdateHighScores(int newScore) {
        int previousHighscore = newScore;

        foreach(int highscore in playerData.highscores) {
            // Replace all scores in file in descending order
            if(previousHighscore > highscore) { 
                newScore = previousHighscore;
                previousHighscore = highscore;
                playerData.highscores[highscore] = newScore;
            }
        }
    } 
}

[System.Serializable]
public class PlayerData {
    public int[] highscores = new int[10];
}