using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookaround : MonoBehaviour
{
    ///Camera
    public float sensitivity = 100f;
    public Transform playerBody;
    public Camera cam;

    public float xRotation = 0f;



    public void Start() {
        playerBody = this.transform;
        Cursor.lockState = CursorLockMode.Locked;
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
        
        ///Camera
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}