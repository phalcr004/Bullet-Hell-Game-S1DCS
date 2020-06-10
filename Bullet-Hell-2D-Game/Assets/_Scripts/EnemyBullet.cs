using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    // Speed of enemy bullets
    private float bulletSpeed = 3f;

    // Boundaries
    private float xBoundary = 15f;
    private float yBoundary = 5.5f;

    void Update() {
        // Move "up" relative to bullet
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);

        // Destroy if out of bounds
        if(transform.position.x < -xBoundary || transform.position.x > xBoundary || transform.position.y < -yBoundary || transform.position.y > yBoundary) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        // Take a life from player
        PlayerController.playerLives -= 1;

        // Remove the projectile
        Destroy(gameObject);
    }
}
