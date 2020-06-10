using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanShooter : MonoBehaviour
{
    public float enemySpeed = 0.01f;
    private float finalXPos;
    [SerializeField] float sinAmp = 0.25f;
    public int enemyAction;
    private float timer;

    private float spawnBounds = 360f;

    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;
    [Range(0, 1)] [SerializeField] float movementFactor;
    Vector3 startingPos;
    public float timeInGame;

    public GameObject bean;
    public GameObject spawnZone;
    // Start is called before the first frame update
    void Start()
    {
        //randomly chooses where enemy's final x coord will be
        finalXPos = Random.Range(0f, 7f);
        //when enemy spawns it will begin by moving on screen
        enemyAction = 3;
        timeInGame = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(bean, spawnZone.transform.position, Quaternion.Euler(0, 0, Random.Range(-spawnBounds, spawnBounds)));
        //switch to decide on how enemy will act
        switch (enemyAction)
        {
            case 3:
                    MoveOnScreen();
                break;
            case 2:
                    JackHill();
                break;
            case 1:
                    MoveOffScreen();
                break;
        }

    }
    //enemy will move from spawn to randomly chosen x
    void MoveOnScreen()
    {
        //If the enemy isn't at the randomly selected x keep moving
        if (transform.position.x > finalXPos)
        {
            transform.Translate(Vector2.left * enemySpeed);
        }
        //once enemy reaches final x, set this position as starting position for sin wave
        else
        {
            startingPos = transform.position;
            enemyAction = 2;
        }
    }
    void JackHill()
    {
        //sit and float
        IdleFloat();
        timeInGame += 1 * Time.deltaTime;
        if(timeInGame > 10f)
        {
            enemyAction = 1;
        }
    }
    void MoveOffScreen()
    {
        //go off screen and destroy self once off
        transform.Translate(Vector2.up * enemySpeed);
        if(transform.position.y > 6.5f)
        {
            Destroy(gameObject);
        }
    }
    private void IdleFloat()
    {
        float cycle = Time.time / period;

        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycle * tau);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If hit player, remove a life
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.playerLives -= 1;
        }
    }
    public void ActionOnDeath()
    {
        Instantiate(bean, spawnZone.transform.position, Quaternion.AngleAxis(Random.Range(-spawnBounds, spawnBounds), Vector3.up));
    }
}

