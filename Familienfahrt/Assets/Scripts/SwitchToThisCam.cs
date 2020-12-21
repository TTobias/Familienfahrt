using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchToThisCam : MonoBehaviour
{
    public KeyCode buttonDown;
    public int priorityChange = 20;

    private CinemachineVirtualCamera vcam;

    // Start is called before the first frame update
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(buttonDown))
        {
            if (vcam.Priority == priorityChange)
            {
                vcam.Priority = 0;
            }
            else
            {
                vcam.Priority = priorityChange;
            }
        }
    }
}
