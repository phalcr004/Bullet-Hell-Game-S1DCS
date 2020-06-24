using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    // Health of enemy
    [SerializeField] int health;

    public void DealDamage(int damageDealt) {
        // Get the script on the enemy with this interface
        IEnemy enemyScript = gameObject.GetComponent<IEnemy>();

        // If enemy cant take damage, return
        if(!enemyScript.CanTakeDamage()) {
            return;
        }

        // Deal damage to enemy
        health -= damageDealt;

        // If enemy's health is less than 1, perform any actions on death
        if(health < 1) {
            enemyScript.ActionOnDeath();
        }
    }
}

// Create interface to ensure all enemies have these methods
public interface IEnemy {
    bool CanTakeDamage();
    void ActionOnDeath();
}
