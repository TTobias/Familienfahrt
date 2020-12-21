using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMovement : MonoBehaviour {

    public Transform car;
    public float speed = 0f;
    public float maxSpeed = 18f;
    public float acceleration = 0.3f;

    public string speedText = "";
    public Text text;

    public float rotationStrength = 3f;

    public void Start() {
        car = this.transform;
    }

    public void FixedUpdate() {
        speedText = (int)(speed * 3f) + " km/h";
        text.text = speedText;
        move();
        rotate();
    }

    public void move() {
        float tmp = Input.GetAxis("Vertical");
        if (tmp < 0) tmp *= 5f;
        speed += acceleration * tmp * Time.deltaTime;
        if (speed > maxSpeed) speed = maxSpeed;
        if (speed < 0) speed = 0;
        car.transform.position += car.transform.forward * Time.fixedDeltaTime * speed;
    }

    public void rotate() {
        float tmpRotationStrength = rotationStrength * 0.6f + rotationStrength * 0.4f * (maxSpeed / speed );

        float tmpX = 0f;
        float tmpZ = 0f;

        if(car.rotation.eulerAngles.x > 60f) {
            tmpX = -1.5f;
        }
        if (car.rotation.eulerAngles.x < -60f) {
            tmpX =  1.5f;
        }
        if (car.rotation.eulerAngles.z > 60f) {
            tmpZ = -1.5f;
        }
        if (car.rotation.eulerAngles.z < -60f) {
            tmpZ =  1.5f;
        }


        car.transform.rotation = car.transform.rotation * Quaternion.Euler(tmpX, Input.GetAxis("Horizontal") * rotationStrength, tmpZ); 
    }
}
