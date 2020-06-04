using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyButtons : MonoBehaviour
{
    [SerializeField] AudioSource cameraAudio;
    public AudioClip easySelectSound;
    public AudioClip mediumSelectSound;
    public AudioClip hardSelectSound;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        cameraAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetDifficultyEasy()
    {
        PlayerController.playerLives = 2;
        Debug.Log("Difficulty Set to Easy");
        cameraAudio.PlayOneShot(easySelectSound, 1.0f);
        Invoke("StartGame", 1);
    }
    public void SetDifficultyMeduim()
    {
        PlayerController.playerLives = 1;
        Debug.Log("Difficulty Set to Medium");
        cameraAudio.PlayOneShot(mediumSelectSound, 1.0f);
        Invoke("StartGame", 2);
    }
    public void SetDifficultyHard()
    {
        PlayerController.playerLives = 0;
        Debug.Log("Difficulty Set to Hard");
        cameraAudio.PlayOneShot(hardSelectSound, 0.75f);
        Invoke("StartGame", 2);
    }
    public void StartGame()
    {
            SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
