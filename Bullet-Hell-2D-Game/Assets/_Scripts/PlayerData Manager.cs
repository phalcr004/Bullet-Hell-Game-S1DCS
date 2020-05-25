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

    public static void OverwriteJsonFile() {
        JsonUtility.ToJson(playerData);
    }
}

[System.Serializable]
public class PlayerData {
    public Highscores[] highscores;
}

[System.Serializable]
public class Highscores {
    public int position;
    public int score;
}
