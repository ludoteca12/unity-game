using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 0.3f;
    public float boundY = 0.15f;

    //Late beacause it happen before the player update
    private void LateUpdate() {
        Vector3 delta = Vector3.zero;

        //check if the player is inside the bounds of the camera on the X axis
        float deltaX = lookAt.position.x - transform.position.x;
        if(deltaX > boundX || deltaX < -boundX) {

            if(transform.position.x < lookAt.position.x) {
                delta.x = deltaX - boundX;
            } else {
                delta.x = deltaX + boundX; 
            }
        }

        //check if the player is inside the bounds of the camera on the Y axis
        float deltaY = lookAt.position.y - transform.position.y;
        if(deltaY > boundY || deltaY < -boundY) {

            if(transform.position.y < lookAt.position.y) {
                delta.y = deltaY - boundY;
            } else {
                delta.y = deltaY + boundY; 
            }
        }

        transform.position += new Vector3 (delta.x, delta.y, 0);
    }
}
