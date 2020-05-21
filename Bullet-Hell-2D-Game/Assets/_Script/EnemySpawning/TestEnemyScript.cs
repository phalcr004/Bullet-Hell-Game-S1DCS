using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyScript : MonoBehaviour {
    private float speed = 3f;

    void Update() {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if(transform.position.x < -15) {
            Destroy(gameObject);
        }
    }
}
