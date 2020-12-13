using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetPathFinder : MonoBehaviour
{
    public StreetPathPoint targetPathPoint;
    public float rotationSpeed = 10f;
    public float speed = 50f;


    Vector3 tmpDir;
    Quaternion tmpRot;
    public void FixedUpdate() {

        //Rotate
        tmpDir = (targetPathPoint.transform.position - transform.position).normalized;
        tmpRot = Quaternion.LookRotation(tmpDir);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, tmpRot, Time.deltaTime * rotationSpeed);

        //Move
        this.transform.position += this.transform.forward * Time.deltaTime * speed;

        if(Vector3.Distance (targetPathPoint.transform.position, this.transform.position) < 5f) {
            targetPathPoint = targetPathPoint.next[(int)Random.Range(0, targetPathPoint.next.Count - 0.001f)];
            speed = targetPathPoint.localSpeed;
        }
    }
}
