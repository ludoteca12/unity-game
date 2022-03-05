using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D BoxCollider;

    private Vector3 moveDelta;

    private void Start() {
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Reset moveDelta
        moveDelta = new Vector3(x, y, 0);

        // Swap sprite direction
        if(moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if(moveDelta.x < 0) 
            transform.localScale = new Vector3(-1, 1, 1);

        // Adding movement
        transform.Translate(moveDelta * Time.deltaTime);
        
    }
}
