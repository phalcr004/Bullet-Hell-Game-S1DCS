using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static int startingLives;
    public static int playerLives;
    public static int score;
    private float speed;
    private float fastSpeed =5.5f;
    private float slowSpeed = 2.5f;

    public bool isPaused;
    public bool isNotPaused;

    public Image extraLife1;
    public Image extraLife2;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Transform bulletSpawn2;

    private AudioSource cameraAudio;

    private float xBound = 8.5f;
    private float yBound = 4.6f;

    public float delay = 0.06f;
    private float nextTime;

    // Start is called before the first frame update
    void Start()
    {
        playerLives = startingLives;
        Time.timeScale = 1;
        isNotPaused = true;
        cameraAudio = GameObject.Find("GameManager").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        FireWeapon();
        //Pause Script
        /*        if (Input.GetKeyDown(KeyCode.Escape && ))
            {
                if (isNotPaused)
                {
                    isNotPaused = false;
                    Time.timeScale = 1;
                    cameraAudio.Pause();
                }
                else
                {
                    isNotPaused = true;
                    Time.timeScale = 0;
                    cameraAudio.UnPause();
                }
            }*/
        //Hud Display For Player Lives
        switch (playerLives)
        {
            case 2:
                extraLife1.enabled = true;
                extraLife1.enabled = true;
                break;
            case 1:
                extraLife1.enabled = true;
                extraLife2.enabled = false;
                break;
            case 0:
                extraLife1.enabled = false; 
                extraLife2.enabled = false;
                break;
            case -1:
                extraLife1.enabled = false;
                extraLife2.enabled = false;
                break;
        }
    }
    private void MovePlayer()
    {
        //If the player holds shift, move slower
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = slowSpeed;
        }
        //Otherwise use the fast speed
        else
        {
            speed = fastSpeed;
        }
        //These if Statements move the player and keep them in the boundaries
        if (Input.GetKey(KeyCode.W) && transform.position.y < 4.6)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -xBound)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > -yBound)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < xBound)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
    private void FireWeapon()
    {
        if (Input.GetKey(KeyCode.J))
        {
            if(Time.time > nextTime)
            {
                Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                Instantiate(bullet, bulletSpawn2.position, bulletSpawn.rotation);
                nextTime = Time.time + delay;
            }
        }
    }

} 
