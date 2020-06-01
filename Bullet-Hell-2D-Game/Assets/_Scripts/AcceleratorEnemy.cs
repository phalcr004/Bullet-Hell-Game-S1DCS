using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratorEnemy : MonoBehaviour {
    private float speed = 5f;
    private float acceleration = 0.3f;
    private float health = 5000f;

    private enum EnemyStates { Spawning, Targetting, Charging }
    private EnemyStates enemyState;
    
    private bool canTakeDamage;
    private float timer;
    private float invincibilityDuration = 0.5f;
    private float targettingUpdateDelay = 2f;

    private Transform playerTransform;
    private Vector2 directionToPlayer;

    void Start() {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();

        transform.Rotate(new Vector3(0, 0, 180));
        enemyState = EnemyStates.Spawning;
        canTakeDamage = false;
        timer = Time.time + invincibilityDuration;
    }

    // Update is called once per frame
    void Update() {
        switch(enemyState) {
            case EnemyStates.Spawning:
                MoveOnSpawn();
                break;
            case EnemyStates.Targetting:
                TargetPlayer();
                break;
            case EnemyStates.Charging:
                AccelerateTowardsPlayer();
                break;
        }
    }

    private void MoveOnSpawn() {
        if(Time.time > timer) {
            enemyState = EnemyStates.Targetting;
            Debug.Log("State changed to targetting");
            canTakeDamage = true;
        }
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void TargetPlayer() {
        timer = Time.time + targettingUpdateDelay;
        directionToPlayer = (playerTransform.position - transform.position).normalized;
        enemyState = EnemyStates.Charging;
        Debug.Log("State changed to charging");
    }

    private void AccelerateTowardsPlayer() {
        if(Time.time > timer) {
            enemyState = EnemyStates.Targetting;
            Debug.Log("State changed to targetting");
        }
        speed += acceleration * Time.deltaTime;
        transform.Translate(directionToPlayer * -speed * Time.deltaTime);
    }
}
