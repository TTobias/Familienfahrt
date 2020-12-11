using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour {

    public Transform car;
    public float speed;
    
    public void Start() {
        car = this.transform;
    }

    public void FixedUpdate() {

        move();
        rotate();
    }

    public void move() {
        car.transform.position += car.transform.forward * Time.deltaTime * speed * Input.GetAxis("Vertical");
    }

    public void rotate() {
        car.transform.rotation = car.transform.rotation * Quaternion.Euler(0f, Input.GetAxis("Horizontal") * 3f, 0f);
    }
}
