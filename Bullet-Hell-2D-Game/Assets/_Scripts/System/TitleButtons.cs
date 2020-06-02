using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButtons : MonoBehaviour
{
    public static bool gameAudio = true;
    [SerializeField] AudioListener cameraAudio;

    [SerializeField] Button muteButton;
    public Sprite unmute;
    public Sprite mute;
    Image muteComponent;


    private bool helpScreenActive;
    private bool helpScreen2Active;
    private bool startScreenActive;
    private bool difficultyScreenActive;
    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject startDifficultyButtons;
    [SerializeField] GameObject helpScreen;
    [SerializeField] GameObject helpScreen2;
    [SerializeField] GameObject title;

    // Start is called before the first frame update
    void Start()
    {
        //set Play, Help, Exit buttons on and Easy, Medium, Hard buttons off
        startScreenActive = true;
        difficultyScreenActive = false;
        muteComponent = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //if startscreenactive is true show Play Help buttons and don't show difficulty buttons

        //if gameAudio is true turn AudioListener volume on and change mute button sprite to unmuted
        if (gameAudio == true)
        {
            AudioListener.volume = 0.75f;
            muteComponent.sprite = unmute;
        }
        if (gameAudio == false)
        {
            AudioListener.volume = 0f;
            muteComponent.sprite = mute;
        }
    }
    public void CloseGame()
    {
        //Closes Application
        Application.Quit();
    }
    public void MuteGame()
    {
        //if activates will swap bool to false/true
        if (gameAudio == true)
        {
            Debug.Log("Game Muted");
            gameAudio = false;
        }
        else
        {
            Debug.Log("Game Unmuted");
            gameAudio = true;
        }

    }
    public void ClickPlay()
    {
        startScreenActive = false;
        startScreen.SetActive(false);
        startDifficultyButtons.SetActive(true);
        difficultyScreenActive = true;
    }
    public void ClickHelp()
    {
        startScreenActive = false;
        startScreen.SetActive(false);
        helpScreen.SetActive(true);
        helpScreenActive = true;
        title.SetActive(false);
    }
    public void ClickBack()
    {
        startScreenActive = true;
        startScreen.SetActive(true);
        startDifficultyButtons.SetActive(false);
        difficultyScreenActive = false;
        helpScreenActive = false;
        helpScreen.SetActive(false);
        title.SetActive(true);
        helpScreen2Active = false;
        helpScreen2.SetActive(false);

    }
    public void ClickMore()
    {
        helpScreenActive = false;
        helpScreen.SetActive(false);
        helpScreen2Active = true;
        helpScreen2.SetActive(true);

    }
    public void ClickRightArrow()
    {
        helpScreenActive = true;
        helpScreen.SetActive(true);
        helpScreen2Active = false;
        helpScreen2.SetActive(false);
        helpScreen.SetActive(true);
        helpScreenActive = true;

    }
    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void exitGame()
    {
        SceneManager.LoadScene(0);
    }
}

