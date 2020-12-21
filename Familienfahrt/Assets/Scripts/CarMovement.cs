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

    public MoodCalculator mood;
    public float crashCounter = 0f;
    public float crashDetector = 200f;

    public void Start() {
        car = this.transform;
    }

    public void FixedUpdate() {
        speedText = (int)(speed * 3f) + " km/h";
        text.text = speedText;
        move();
        rotate();


        if( crashCounter > crashDetector) {
            mood.carCrashed();
        }
    }

    public void move() {
        float tmp = Input.GetAxis("Vertical");
        if (tmp < 0) tmp *= 5f;
        speed += acceleration * tmp * Time.deltaTime;
        if (speed > maxSpeed) speed = maxSpeed;
        if (speed < 0) speed = 0;

        Debug.Log(car.localEulerAngles.x + "      " + car.localEulerAngles.z);
        if ((car.localEulerAngles.x < 40f || car.localEulerAngles.x > 320f) && (car.localEulerAngles.z < 40f || car.localEulerAngles.z > 320f)) {
            car.transform.position += car.transform.forward * Time.fixedDeltaTime * speed;
            crashCounter = 0f;
        }
        else {
            crashCounter++;
        }
    }

    public void rotate() {
        float tmpRotationStrength = rotationStrength * 0.6f + rotationStrength * 0.4f * (maxSpeed / speed );

        float tmpX = 0f;
        float tmpZ = 0f;

        car.transform.rotation = car.transform.rotation * Quaternion.Euler(tmpX, Input.GetAxis("Horizontal") * rotationStrength, tmpZ); 
    }
}
