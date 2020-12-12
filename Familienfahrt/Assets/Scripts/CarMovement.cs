using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    public Transform car;
    public float speed = 0f;
    public float maxSpeed = 15f;
    public float acceleration = 0.3f;
    
    public void Start() {
        car = this.transform;
    }

    public void FixedUpdate() {
        move();
        rotate();
    }

    public void move() {
        speed += acceleration * Input.GetAxis("Vertical") * Time.deltaTime;
        if (speed > maxSpeed) speed = maxSpeed;
        if (speed < 0) speed = 0;
        car.transform.position += car.transform.forward * Time.deltaTime * speed;
    }

    public void rotate() {
        car.transform.rotation = car.transform.rotation * Quaternion.Euler(0f, Input.GetAxis("Horizontal") * 3f, 0f);
    }
}
