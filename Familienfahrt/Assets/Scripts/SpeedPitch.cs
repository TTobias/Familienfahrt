using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPitch : MonoBehaviour
{
    private AudioSource aSource;
    public CarMovement cm;

    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cm == null) return;

        aSource.pitch = Mathf.Lerp(.5f, 2f, cm.speed / cm.maxSpeed );
    }
}
