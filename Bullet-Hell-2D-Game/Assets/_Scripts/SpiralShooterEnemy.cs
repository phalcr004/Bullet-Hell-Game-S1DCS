﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralShooterEnemy : MonoBehaviour {
    // 
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject[] projectileSpawns;
    private Transform spinnerTransform;

    // Speed of enemy and spin
    private float speed = 1f;
    private float spinSpeed;

    // Track enemy state and adjust "AI" accordingly
    private enum EnemyStates { Spawning, Shooting, Spinning }
    private EnemyStates enemyState;

    // Stop player from destroying enemy before it begins spin
    public bool canTakeDamage;
    private float invincibilityDuration = 2f;

    // Timer to keep track of state changes
    private float timer;

    // Delay between spinning and shooting states
    private float shootDelay = 0.25f;

    void Start() {
        spinnerTransform = GameObject.Find("Spinner").GetComponent<Transform>();

        // Rotate enemy so sprite faces correct direction
        transform.Rotate(new Vector3(0f, 0f, 180f));

        // Initialise variables
        enemyState = EnemyStates.Spawning;
        canTakeDamage = false;
        timer = Time.time + invincibilityDuration;
    }

    void Update() {
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
        // If the invincibility should end, change state and begin "AI"
        if (Time.time > timer) {
            enemyState = EnemyStates.Shooting;
            canTakeDamage = true;
        }

        // Move in the "forward" direction of the sprite
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void ShootProjectiles() {
        for(int i = 0; i < projectileSpawns.Length; i++) {
            Instantiate(projectile, projectileSpawns[i].transform.position, projectileSpawns[i].transform.rotation, spinnerTransform);
        }
        timer = Time.time + shootDelay;
        enemyState = EnemyStates.Spinning;
    }

    private void SpinProjectiles() {
        if(Time.time > timer) {
            enemyState = EnemyStates.Shooting;
        }
        spinnerTransform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(!canTakeDamage) {
            return;
        }

        // If hit player, remove a life
        if (collision.gameObject.CompareTag("Player")) {
            PlayerController.playerLives -= 1;
        }
    }
}
