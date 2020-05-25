using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float fastSpeed =5.5f;
    [SerializeField] float slowSpeed = 2.5f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Transform bulletSpawn2;
    private float xBound = 8.5f;
    private float yBound = 4.6f;

    public float delay = 0.06f;
    private float nextTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        FireWeapon();
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
