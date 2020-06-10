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
            canTakeDamage = enemyScript.canTakeDamage;
        }
        catch(NullReferenceException e) {}
        try {
            SpiralShooterEnemy enemyScript = gameObject.GetComponent<SpiralShooterEnemy>();
            canTakeDamage = enemyScript.canTakeDamage;
        }

        catch(NullReferenceException e) {}

        try
        {
            BeanShooter enemyScript = gameObject.GetComponent<BeanShooter>();
            canTakeDamage = true;
        }
        catch (NullReferenceException e) { }
        if (!canTakeDamage) {
            return;
        }

        health -= damageDealt;
        if(health < 1) {
            Destroy(gameObject);
        }

    }
}

public interface IEnemy {
    public void 
}
