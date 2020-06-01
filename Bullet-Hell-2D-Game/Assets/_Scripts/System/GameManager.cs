using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioClip[] music;
    private AudioClip selectedMusic;
    [SerializeField] AudioSource cameraAudio;
    [SerializeField] AudioListener cameraVolume;
    public AudioClip bossMusic;

    public bool isGameActive;
    public bool activateBoss;
    public bool isBossActive;

    // Start is called before the first frame update
    void Start()
    {
        isBossActive = false;
        ChooseMusic();
        isGameActive = true;
        if(TitleButtons.gameAudio == false)
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = .5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activateBoss == true)
        {
            activateBoss = false;
            ActivateBoss();
        }
    }
    public void GameOver()
    {
        isGameActive = false;
        AudioListener.volume = 0.25f;
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
