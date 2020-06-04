using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    // Health of enemy
    [SerializeField] int health;
    public bool canTakeDamage;

    public void DealDamage(int damageDealt) {
        try {
            AcceleratorEnemy enemyScript = gameObject.GetComponent<AcceleratorEnemy>();
            this.canTakeDamage = enemyScript.canTakeDamage;
        }
        catch(NullReferenceException e) {

        }
        try {
            SpiralShooterEnemy enemyScript = gameObject.GetComponent<SpiralShooterEnemy>();
            this.canTakeDamage = enemyScript.canTakeDamage;
        }
        catch(NullReferenceException e) {

        }

        if(!canTakeDamage) {
            return;
        }

        health -= damageDealt;
        if(health < 1) {
            Destroy(gameObject);
        }
    }
}
