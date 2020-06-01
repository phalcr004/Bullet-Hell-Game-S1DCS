using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Richochet : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D collision) {
        Transform bulletTransform = collision.gameObject.transform;

        bulletTransform.position = Vector2.Reflect(transform.position, collision.GetContact(0).normal);
    }
}
