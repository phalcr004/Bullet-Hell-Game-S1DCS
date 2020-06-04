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

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player")) {
            return;
        }

        collision.gameObject.GetComponent<EnemyHealth>().DealDamage(bulletDamage);
    }
}
