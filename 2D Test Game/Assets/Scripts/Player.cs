using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D BoxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;

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

        // Adding Colision, checking if the player(Actor Layer) can move in this direction
        hit = Physics2D.BoxCast(transform.position, BoxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider == null) {
            // Adding movement
                            //  x,       y,                       z
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, BoxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));
        if(hit.collider == null) {
            // Adding movement
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

        
    }
}
