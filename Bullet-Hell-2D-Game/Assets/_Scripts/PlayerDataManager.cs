using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerDataManager : MonoBehaviour {
    private string path;
    private string jsonString;

    public static PlayerData playerData;
    void Start() {
        path = Application.streamingAssetsPath + "/player-data.JSON";
        jsonString = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<PlayerData>(jsonString);
    }

    public void OverwriteJsonFile() {
        JsonUtility.ToJson(playerData);
    }

    public void UpdateHighScores(int newScore) {
        int previousHighscore = newScore;

        foreach(Highscores highscore in playerData.highscores) {
            if(previousHighscore > highscore.score) { 
                newScore = previousHighscore;
                previousHighscore = highscore.score;
                highscore.score = newScore;
            }
        }
    } 

}

[System.Serializable]
public class PlayerData {
    public Highscores[] highscores;
}

[System.Serializable]
public class Highscores {
    public int score;
}
