using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class SpiralShooterEnemy : MonoBehaviour, IEnemy {
    // GameObjects for spawning projectiles
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject[] projectileSpawns;
    [SerializeField] GameObject spinner;

    // Speed of enemy and spin
    private float speed = 3f;
    [SerializeField] float spinSpeed = 15f;

    // Track enemy state and adjust "AI" accordingly
    private enum EnemyStates { Spawning, Shooting, Spinning }
    private EnemyStates enemyState;

    // Stop player from destroying enemy before it begins spin
    public bool canTakeDamage;
    private float invincibilityDuration = 2.5f;

    // Timer to keep track of state changes
    private float timer;

    // Delay between spinning and shooting states
    private float shootDelay = 0.5f;

    void Start() {
        // Rotate enemy so sprite faces correct direction
        transform.Rotate(new Vector3(0f, 0f, 180f));

        // Initialise variables
        enemyState = EnemyStates.Spawning;
        canTakeDamage = false;
        timer = Time.time + invincibilityDuration;
    }

    void Update() {
        // Run code every frame based on state of enemy
        switch(enemyState) {
            case EnemyStates.Spawning:
                MoveOnSpawn();
                break;
            case EnemyStates.Shooting:
                ShootProjectiles();
                break;
            case EnemyStates.Spinning:
                SpinProjectiles();
                break;
        }
    }

    private void MoveOnSpawn() { 
        if (Time.time > timer) {
            // Change state and end invincibility period
            enemyState = EnemyStates.Shooting;
            canTakeDamage = true;
        }

        // Move in the "forward" direction of the sprite
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void ShootProjectiles() {
        // Spawn a bullet in each spawn zone attached to the enemy
        for(int i = 0; i < projectileSpawns.Length; i++) {
            Instantiate(projectile, projectileSpawns[i].transform.position, projectileSpawns[i].transform.rotation, spinner.transform);
        }

        // Set up timer for next shot and change state
        timer = Time.time + shootDelay;
        enemyState = EnemyStates.Spinning;
    }

    private void SpinProjectiles() {
        if(Time.time > timer) {
            // Change state to shooting if timer is over
            enemyState = EnemyStates.Shooting;
        }
        // Rotate the enemy and the "spinner" to create the spiral effect
        transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
        spinner.transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // If hit player, remove a life
        if (collision.gameObject.CompareTag("Player")) {
            PlayerController.playerLives -= 1;
        }
    }

    // Return whether the enemy can take damage
    public bool CanTakeDamage() {
        return canTakeDamage;
    }

    // Destroy on death
    public void ActionOnDeath() {
        Destroy(gameObject);
    }
}
