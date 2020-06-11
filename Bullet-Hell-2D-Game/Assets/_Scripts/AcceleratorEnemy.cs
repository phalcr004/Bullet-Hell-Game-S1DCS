using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyHealth))]
public class AcceleratorEnemy : MonoBehaviour, IEnemy {
    // Acceleration and initial speed
    private float speed = 1f;
    private float acceleration = 15f;

    // Track enemy state and adjust "AI" accordingly
    private enum EnemyStates { Spawning, Targetting, Charging }
    private EnemyStates enemyState;
    
    // Stop player from destroying enemy before it fully enters screen
    public bool canTakeDamage;
    private float invincibilityDuration = 2f;

    // Timer to keep track of state changes
    private float timer;
    
    // Delay between moving and targetting states
    private float targettingUpdateDelay = 0.1f;

    // Transform of the player
    private Transform playerTransform;

    // Rigidbody of the enemy  
    private Rigidbody2D rigidbody;

    // Direction and distance variables
    private Vector2 directionToPlayer;
    private float distanceToPlayer;
    private float minDistanceFromPlayer = 5f;

    // Boundaries
    private float xBoundary = 15f;
    private float yBoundary = 4.5f;

    void Start() {
        // Find player transform and enemy rigidbody
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();

        // Rotate enemy so sprite faces correct direction
        transform.Rotate(new Vector3(0f, 0f, 180f));

        // Initialise variables
        enemyState = EnemyStates.Spawning;
        canTakeDamage = false;
        timer = Time.time + invincibilityDuration;
    }

    // Update is called once per frame
    void Update() {
        switch(enemyState) {
            case EnemyStates.Spawning:
                // Period of invincibility before attacking
                MoveOnSpawn();
                break;
            case EnemyStates.Targetting:
                // Targets the player
                TargetPlayer();
                break;
        }
        // If the grace period is over
        if(enemyState != EnemyStates.Spawning) {
            // Destroy enemy if moves off screen (i.e player dodges)
            if(transform.position.x < -xBoundary || transform.position.x > xBoundary || transform.position.y < -yBoundary || transform.position.y > yBoundary) {
                Destroy(gameObject);
            }
        }
    }

    void FixedUpdate() {
        if(enemyState == EnemyStates.Charging) {
            // Moves in direction of target
            AccelerateTowardsPlayer();
        }
    }

    private void MoveOnSpawn() {
        // If the invincibility should end, change state and begin "AI"
        if(Time.time > timer) {
            enemyState = EnemyStates.Targetting;
            canTakeDamage = true;
        }

        // Move in the "forward" direction of the sprite
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void TargetPlayer() {
        // Keep track of how long before returning to this method
        timer = Time.time + targettingUpdateDelay;

        // Get the distance and direction between enemy and player
        distanceToPlayer = (playerTransform.position - transform.position).magnitude;
        directionToPlayer = (playerTransform.position - transform.position).normalized;

        // Rotate the enemy "forwards" towards the player 
        transform.up = -directionToPlayer;

        // Change state to charging
        enemyState = EnemyStates.Charging;
    }

    private void AccelerateTowardsPlayer() {
        // If the targetting timer is over and the enemy is not too close to the player:
        if(Time.time > timer && distanceToPlayer > minDistanceFromPlayer) {
            // Run the targetPlayer method
            enemyState = EnemyStates.Targetting;
        }
        // Accelerate by x units/s/s
        speed += acceleration * Time.deltaTime;

        // Move in the "forward" direction relative to the sprite
        Vector2 moveVector = directionToPlayer * speed * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + moveVector);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(!canTakeDamage) {
            return;
        }
        
        // If hit player, remove a life
        if(collision.gameObject.CompareTag("Player")) {
            PlayerController.playerLives -= 1;
            Destroy(gameObject);
        }
    }

    public bool CanTakeDamage() {
        return canTakeDamage;
    }

    public void ActionOnDeath() {
        Destroy(gameObject);
    }
}
