using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HONK : MonoBehaviour
{
    private AudioSource aSource;
    public AudioClip clip;
    public float cooldown = 1.5f;

    private float cd;

    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        cd = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= cd)
        {
            aSource.PlayOneShot(clip);

            cd = Time.time + cooldown;
        }
    }
}
