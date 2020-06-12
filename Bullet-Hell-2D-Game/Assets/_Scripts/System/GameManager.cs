using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public AudioClip[] music;
    private AudioClip selectedMusic;
    public AudioSource cameraAudio;
    [SerializeField] AudioListener cameraVolume;
    public AudioClip bossMusic;
    public PlayerDataManager playerDataManager;
    public bool isGameActive;
    public bool activateBoss;
    public bool isBossActive;

    public GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {  //when game starts set these
        ChooseMusic();
        Debug.LogError(playerDataManager.playerData);
        highScoreText.text = "High Score" + playerDataManager.playerData.highscores[0];
        isBossActive = false;
        isGameActive = true;
        //Turn audio on if not muted
        if (TitleButtons.gameAudio == false)
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = .2f;
        }
    }

    // Update is called once per frame
    void Update()
    {   //check if boss is active or not
        if (activateBoss == true)
        {
            activateBoss = false;
            ActivateBoss();
        }
        //Check if player has no more lives
        if(PlayerController.playerLives < 0)
        {
            GameOver();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            GameOver();
        }
        scoreText.text = "" + PlayerController.score;
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        isGameActive = false;
        AudioListener.volume = 0.1f;
        gameOverScreen.SetActive(true);
    }
    public void ChooseMusic()
    {
        int musicChoice = Random.Range(0, music.Length);
        cameraAudio.clip = music[musicChoice]; 
        cameraAudio.Play();
        
    }
    public void ActivateBoss()
    {
        isBossActive =true;
        cameraAudio.Stop();
        cameraAudio.PlayOneShot(bossMusic,1f);
    }
}
