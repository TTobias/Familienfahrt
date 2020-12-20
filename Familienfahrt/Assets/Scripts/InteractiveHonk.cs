using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveHonk : MonoBehaviour
{
    private AudioSource aSource;
    public AudioClip clip;
    public float cooldown = 1.5f;
    public TMPro.TextMeshProUGUI hoverText;

    Ray ray;
    RaycastHit hit;
    State state = State.None;
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
        if (Input.GetMouseButtonDown(0) && state == State.Over && Time.time >= cd)
        {
            aSource.PlayOneShot(clip);
            cd = Time.time + cooldown;
        }

    }

    void FixedUpdate()
    {
        switch (state)
        {
            case State.None:
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.name == "HONK")
                    {
                        state = State.Over;
                        hoverText.gameObject.SetActive(true);
                    }

                }
                break;
            case State.Over:
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (!(hit.collider.name == "HONK" ))
                    {
                        state = State.None;
                        hoverText.gameObject.SetActive(false);
                    }
                }
                break;
            default:
                break;
        }
    }

    enum State
    {
        None, Over
    }
}
