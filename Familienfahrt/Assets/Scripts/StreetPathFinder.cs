using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetPathFinder : MonoBehaviour
{
    public StreetPathPoint targetPathPoint;
    public float rotationSpeed = 10f;
    public float speed = 50f;

    public bool isTruck = false;

    public void Start() {
        loadRandomCar();
    }

    public void loadRandomCar() {
        if (isTruck) {
            int tmpTruck = (int)Mathf.Floor(Random.Range(0f, 3.98f));
            string tmpTruck2 = tmpTruck == 0 ? "DHLate" : tmpTruck == 1 ? "Globuli" : tmpTruck == 2 ? "Muggi" : "NukaCola";

            Instantiate(Resources.Load("Prefabs Vehicles/" + tmpTruck2), this.transform.position + new Vector3(0f, 0f, 2.7f), this.transform.rotation, this.transform);
        }
        else {
            int tmpColor = (int)Mathf.Floor(Random.Range(0f, 3.98f));
            string tmpColor2 = tmpColor == 0 ? "_blue" : tmpColor == 1 ? "_green" : tmpColor == 2 ? "_red" : "_white";
            int tmpCar = (int)Mathf.Floor(Random.Range(1f, 5.98f));
            string tmpCar2 = tmpCar.ToString();
            
            Instantiate(Resources.Load("Prefabs Vehicles/Car0" + tmpCar2 + tmpColor2), this.transform.position, this.transform.rotation, this.transform);
        }

    }


    Vector3 tmpDir;
    Quaternion tmpRot;
    public void FixedUpdate() {

        //Rotate
        tmpDir = (targetPathPoint.transform.position - transform.position).normalized;
        tmpRot = Quaternion.LookRotation(tmpDir);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, tmpRot, Time.deltaTime * rotationSpeed);

        //Move
        this.transform.position += this.transform.forward * Time.deltaTime * speed * 0.5f;

        if(Vector3.Distance (targetPathPoint.transform.position, this.transform.position) < 5f) {
            targetPathPoint = targetPathPoint.next[(int)Random.Range(0, targetPathPoint.next.Count - 0.001f)];
            speed = targetPathPoint.localSpeed;
        }
    }
}
