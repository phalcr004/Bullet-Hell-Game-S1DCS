using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButtons : MonoBehaviour
{
    [SerializeField] AudioSource cameraAudio;
    public AudioClip easySelectSound;
    public AudioClip mediumSelectSound;
    public AudioClip hardSelectSound;

    // Start is called before the first frame update
    void Start()
    {
        cameraAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetDifficultyEasy()
    {
        Debug.Log("Difficulty Set to Easy");
        cameraAudio.PlayOneShot(easySelectSound, 1.0f);
    }
    public void SetDifficultyMeduim()
    {
        Debug.Log("Difficulty Set to Medium");
        cameraAudio.PlayOneShot(mediumSelectSound, 1.0f);
    }
    public void SetDifficultyHard()
    {
        Debug.Log("Difficulty Set to Hard");
        cameraAudio.PlayOneShot(hardSelectSound, 0.75f);
    }
}
