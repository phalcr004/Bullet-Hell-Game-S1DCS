using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        isGameActive = false;
    }

    public void ManageScene(int scene)
    {
        SceneManager.LoadScene(scene);
        //SceneManager.LoadScene(0);
    }
}
