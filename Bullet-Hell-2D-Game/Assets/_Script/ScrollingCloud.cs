using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCloud : MonoBehaviour {
    [SerializeField] float speed;
    [SerializeField] float xBoundary = -15f;
    [SerializeField] float yTopBoundary = 4.5f;
    [SerializeField] float yBottomBoundary = -3f;

    void Update() {
        transform.Translate(Vector2.left * speed * Time.deltaTime);       

        if(transform.position.x < xBoundary) {
            float randomYPosition = Random.Range(yBottomBoundary, yTopBoundary);
            transform.position = new Vector2(-xBoundary, randomYPosition);
        }
    }
}
