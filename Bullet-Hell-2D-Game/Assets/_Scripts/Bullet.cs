using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int bulletDamage = 10;
    private float bulletSpeed = 15f;

    void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed *Time.deltaTime);
        if (transform.position.x > 9f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        try
        {
            collision.gameObject.GetComponent<EnemyHealth>().DealDamage(bulletDamage);
        }
        catch (NullReferenceException e)
        {
            Debug.LogWarning("Missing enemy health script on enemy: " + collision.gameObject.name);
        }
        Destroy(gameObject);
    }
}
