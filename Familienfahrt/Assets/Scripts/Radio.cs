using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Radio : MonoBehaviour
{
    public AudioClip[] clips;
    public TMPro.TextMeshProUGUI hoverText;
    Ray ray;
    RaycastHit hit;
    State state = State.None;
    AudioSource aSource;


    // Start is called before the first frame update
    void Start()
    {
        aSource = GetComponent<AudioSource>();
        PlayRandomSong();
    }

    void FixedUpdate()
    {
        switch (state)
        {
            case State.None:
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.name == "RadioNextButton")
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
                    if (!(hit.collider.name == "RadioNextButton"))
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && state == State.Over)
        {
            PlayRandomSong();
        }

        if (!aSource.isPlaying)
        {
            PlayRandomSong();
        }
    }

    void PlayRandomSong ()
    {
        aSource.Stop();
        aSource.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }

    enum State
    {
        None, Over
    }
}


