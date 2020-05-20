using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float fastSpeed =5.5f;
    [SerializeField] float slowSpeed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = slowSpeed;
        }
        else
        {
            speed = fastSpeed;
        }
        if (Input.GetKey(KeyCode.W) && transform.position.y < 4.6)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -8.5)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > -4.6)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < 8.5)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
} 
