using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardObject : MonoBehaviour
{
    private Camera main;

    void Start()
    {
        main = Camera.main;
    }

    void FixedUpdate()
    {
        transform.LookAt(main.transform.position, Vector3.up);
    }
}
