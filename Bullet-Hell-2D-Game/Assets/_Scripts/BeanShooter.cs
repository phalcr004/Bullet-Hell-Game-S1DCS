using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanShooter : MonoBehaviour
{
    [SerializeField] float sinAmp = 0.25f;
    public int enemyAction;
    private float timer;

    [SerializeField] Vector3 movementVector;
    [SerializeField] float period = 2f;
    [Range(0, 1)] [SerializeField] float movementFactor;
    Vector3 startingPos;

    //300
    // Start is called before the first frame update
    void Start()
    {
        enemyAction = 3;
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycle = Time.time / period;

        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycle * tau);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
        if (Time.time > timer)
        {
            transform.Rotate(new Vector3(0, 0, 999));
        }
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
    void MoveOnScreen()
    {
        if (transform.position.x != Random.Range(-5, -10))
        {
            transform.Translate(new Vector3(-5, 0, 0));
        }
    }
    void MoveOffScreen()
    {

    }
    void JackHill()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If hit player, remove a life
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.playerLives -= 1;
        }
    }
}

