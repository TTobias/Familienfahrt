using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerLookaround : MonoBehaviour
{
    ///Camera
    public float sensitivity = 100f;
    public Transform playerBody;
    public Camera cam;
    public CinemachineVirtualCamera vcam;

    public MoodCalculator mood;

    public float xRotation = 0f;


    public bool mouseLock = true;


    public void Start() {
        playerBody = this.transform;
    }


    public void FixedUpdate() {
        if (!mood.gameOver) {
            testMouseMode();
            if (mouseLock) {
                Cursor.lockState = CursorLockMode.Locked;
                Lookaround();
            }
            else {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }


    public void testMouseMode() {
        mouseLock = !(Input.GetMouseButton(1)) ;
    }


    public void Lookaround() {

        ///Camera
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        vcam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
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

}