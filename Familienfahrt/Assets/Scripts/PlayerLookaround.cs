using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookaround : MonoBehaviour
{
    public float mouseSensitivity = 1f;
    public Transform player;

    public CharacterController controller;
    public Camera cam;

    public float speed = 0f;

    public float gravity = -9.81f;

    public Vector3 velocity;


    ///Camera
    public float sensitivity = 100f;
    public Transform playerBody;

    public float xRotation = 0f;



    public void Start() {
        player = this.transform;
    }


    public void Update() {


        ///Interact etc (Check for Vehicle)
        /*
        if (Input.GetButtonDown("Interact")) {
            RaycastHit hit;
            Physics.Raycast(cam.transform.position, cam.transform.forward, out hit);

            Debug.Log("created Vehicle Raycast");

            if (hit.collider != null) {
                MovementBehavior tmpVehicle = hit.collider.GetComponent<MovementBehavior>();
                if (tmpVehicle != null) {
                    inputManager.setMovementBehavior(tmpVehicle);
                }
                else {
                    Debug.Log("No Vehicle found");
                }
            }*/
        /*
        if (hit.collider != null) {
            VehicleMount tmpVehicle = hit.collider.GetComponent<VehicleMount>();
            if (tmpVehicle != null) {
                inputManager.setMovementBehavior(tmpVehicle.vehicleMovement);
            }
            else {
                Debug.Log("No Vehicle found");
            }
        }*/
        //}
    }

    public void FixedUpdate() {
        

        ///gravity
        if (velocity.y < 0) {
            velocity.y += gravity;
        }

        ///movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        ///Camera
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}